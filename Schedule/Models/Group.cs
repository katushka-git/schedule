using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Specialty { get; set; }
        public string Number { get; set; }
        public int CountStudents { get; set; }
        public ICollection<ScheduleTable> ScheduleTables { get; set; }

        public Group()
        {
            ScheduleTables = new List<ScheduleTable>();
        }
    }
}