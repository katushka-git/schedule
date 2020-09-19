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
        public int DaysId { get; set; }
        public ICollection<Shedule> Schedules { get; set; }
    }
}