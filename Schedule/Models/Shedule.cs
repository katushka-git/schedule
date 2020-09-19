using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Shedule
    {
        public int Id { get; set; }
        public int CallSheduleId { get; set; }
        public CallShedule CallShedule { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public int ParaId { get; set; }
        public Para Para { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
       public int SubjectId { get;set; }
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


    }
}