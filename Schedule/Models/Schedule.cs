using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class ScheduleTable
        {
        public int  Id { get; set; }
        public int CallSheduleId { get; set; }
        public int ParaId { get; set; }
        public int RoomId { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
    }
}