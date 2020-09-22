using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Teacher
    { 
        public int Id { get; set; }
        public string FIO { get; set; }
        public int SubjectId { get; set; }
        //должность
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        //кафедра
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public Teacher()
        {
            Subjects = new List<Subject>();
        }
    }
}