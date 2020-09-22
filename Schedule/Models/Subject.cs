using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UPlanId { get; set; }
        public UPlan UPlan { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}