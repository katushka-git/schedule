using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public Department()
        {
            Teachers = new List<Teacher>();
        }
    }
}