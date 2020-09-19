﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Teacher
    { 
        public int Id { get; set; }
        public string FIO { get; set; }
        public string SubjectId { get; set; }
        public Subject Subject { get; set; }
        //должность
        public string Position { get; set; }
        //кафедра
        public string Department { get; set; }
        public ICollection<Shedule> Schedules { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}