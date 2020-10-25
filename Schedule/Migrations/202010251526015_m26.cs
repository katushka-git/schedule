namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleTables", "CallSheduleId", "dbo.CallShedules");
            DropForeignKey("dbo.Paras", "DayId", "dbo.Days");
            DropIndex("dbo.ScheduleTables", new[] { "CallSheduleId" });
            DropIndex("dbo.Paras", new[] { "DayId" });
            DropColumn("dbo.ScheduleTables", "CallSheduleId");
            DropColumn("dbo.Paras", "DayId");
            DropTable("dbo.CallShedules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CallShedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamberPar = c.Int(nullable: false),
                        Start = c.Double(nullable: false),
                        Finish = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Paras", "DayId", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleTables", "CallSheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paras", "DayId");
            CreateIndex("dbo.ScheduleTables", "CallSheduleId");
            AddForeignKey("dbo.Paras", "DayId", "dbo.Days", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ScheduleTables", "CallSheduleId", "dbo.CallShedules", "Id", cascadeDelete: true);
        }
    }
}
