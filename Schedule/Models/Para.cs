using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Para
    {
        public int Id { get; set; }
        public int Number { get; set; }
        
        public ICollection<ScheduleTable> ScheduleTables { get; set; }

        public Para()
        {
            ScheduleTables = new List<ScheduleTable>();
        }
    }
}