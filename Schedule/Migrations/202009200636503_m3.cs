namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Schedules", newName: "ScheduleTables");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ScheduleTables", newName: "Schedules");
        }
    }
}
