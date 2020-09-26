namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paras", "DayId", "dbo.Days");
            DropIndex("dbo.Paras", new[] { "DayId" });
            AlterColumn("dbo.Paras", "DayId", c => c.Int(nullable: true));
            CreateIndex("dbo.Paras", "DayId");
            AddForeignKey("dbo.Paras", "DayId", "dbo.Days", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paras", "DayId", "dbo.Days");
            DropIndex("dbo.Paras", new[] { "DayId" });
            AlterColumn("dbo.Paras", "DayId", c => c.Int());
            CreateIndex("dbo.Paras", "DayId");
            AddForeignKey("dbo.Paras", "DayId", "dbo.Days", "Id");
        }
    }
}
