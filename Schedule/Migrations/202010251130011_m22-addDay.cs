namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m22addDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTables", "DayId", c => c.Int(nullable: false));
            CreateIndex("dbo.ScheduleTables", "DayId");
            AddForeignKey("dbo.ScheduleTables", "DayId", "dbo.Days", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleTables", "DayId", "dbo.Days");
            DropIndex("dbo.ScheduleTables", new[] { "DayId" });
            DropColumn("dbo.ScheduleTables", "DayId");
        }
    }
}
