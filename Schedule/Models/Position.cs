﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public Position()
        {
            Teachers = new List<Teacher>();
        }
    }
}