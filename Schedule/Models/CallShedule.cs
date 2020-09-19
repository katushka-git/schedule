using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class CallShedule
    {
        public int Id { get; set; }
        public int NamberPar { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
    }
}