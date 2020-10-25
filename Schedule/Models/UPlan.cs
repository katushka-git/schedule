using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class UPlan
    {
        public int Id { get; set; }
        public int Lecture { get; set; }
        public int Control { get; set; }
        public int Practical { get; set; }
        public int Labor { get; set; }
        public int Coursework { get; set; }
        public int Exam { get; set; }
        public int Zachet { get; set; }
        public int Consultation { get; set; }
        public string NameSubject { get; set; }
        public int Total
        {
            get { return Lecture + Control + Practical + Coursework + Exam + Consultation+ Labor+ Zachet; }
        }
        public ICollection<Subject> Subjects { get; set; }
        public UPlan()
        {
            Subjects = new List<Subject>();
        }
    }
}