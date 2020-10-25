using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public ICollection<ScheduleTable> ScheduleTables { get; set; }

        public Teacher()
        {
            ScheduleTables = new List<ScheduleTable>();
        }
    }
}