﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Para> Paras { get; set; }
        public Day ()
        {
            Paras = new List<Para>();
        }
    }
}