using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
   
        public class PriceViewModel
        {
            public PriceViewModel()
            {
                PhoneBrands = new List<PhoneBrand>();
            }

            public List<PhoneBrand> PhoneBrands { get; set; }

            //кол-во ошибок при импорте
            public int ErrorsTotal { get; set; }
        }
    
}