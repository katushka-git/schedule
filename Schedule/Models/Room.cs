using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        //вместимость 
        public int Capacity { get; set; }
    }
}