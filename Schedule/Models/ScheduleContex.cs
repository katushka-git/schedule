using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class ScheduleContex : DbContext
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<CallShedule> CallShedules { get; set; }
        public DbSet<Para> Paras { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Room> Rooms{ get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet <UPlan> UPlans { get; set; }
        public DbSet<ScheduleTable> ScheduleTables{ get; set; }
        public DbSet <Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}