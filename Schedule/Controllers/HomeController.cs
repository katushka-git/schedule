using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using Schedule.Models;


namespace Schedule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Import(HttpPostedFileBase fileExcel)
        {
            if (ModelState.IsValid)
            {
                PriceViewModel viewModel = new PriceViewModel();
                using (XLWorkbook workBook = new XLWorkbook(fileExcel.InputStream, XLEventTracking.Disabled))
                {
                    foreach (IXLWorksheet worksheet in workBook.Worksheets)
                    {
                        PhoneBrand phoneBrand = new PhoneBrand();
                        phoneBrand.Title = worksheet.Name;

                        foreach (IXLColumn column in worksheet.ColumnsUsed().Skip(1))
                        {
                            PhoneModel phoneModel = new PhoneModel();
                            phoneModel.Title = column.Cell(1).Value.ToString();

                            foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                            {
                                try
                                {
                                    PricePosition pricePosition = new PricePosition();
                                    pricePosition.Problem = row.Cell(1).Value.ToString();
                                    pricePosition.Price = row.Cell(column.ColumnNumber()).Value.ToString();
                                    phoneModel.PricePositions.Add(pricePosition);

                                }
                                catch (Exception e)
                                {
                                    //logging
                                    viewModel.ErrorsTotal++;
                                }
                            }

                            phoneBrand.PhoneModels.Add(phoneModel);
                        }
                        viewModel.PhoneBrands.Add(phoneBrand);
                    }
                }
                //например, здесь сохраняем все позиции из прайса в БД

                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Export()
        {
            List<PhoneBrand> phoneBrands = new List<PhoneBrand>();
            phoneBrands.Add(new PhoneBrand()
            {
                Title = "Apple",
                PhoneModels = new List<PhoneModel>()
            {
                new PhoneModel() { Title = "iPhone 7"},
                new PhoneModel() { Title = "iPhone 7 Plus"}
            }
            });
            phoneBrands.Add(new PhoneBrand()
            {
                Title = "Samsung",
                PhoneModels = new List<PhoneModel>()
            {
                new PhoneModel() { Title = "A3"},
                new PhoneModel() { Title = "A3 2016"},
                new PhoneModel() { Title = "A3 2017"}
            }
            });

            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("Brands");

                worksheet.Cell("A1").Value = "Бренд";
                worksheet.Cell("B1").Value = "Модели";
                worksheet.Row(1).Style.Font.Bold = true;

                //нумерация строк/столбцов начинается с индекса 1 (не 0)
                for (int i = 0; i < phoneBrands.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = phoneBrands[i].Title;
                    worksheet.Cell(i + 2, 2).Value = string.Join(", ", phoneBrands[i].PhoneModels.Select(x => x.Title));
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = $"brands_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }
    }
}