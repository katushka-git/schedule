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
        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}