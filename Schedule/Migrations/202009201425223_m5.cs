namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paras", "DaId", c => c.Int());
            AddColumn("dbo.Paras", "Day_Id", c => c.Int());
            CreateIndex("dbo.Paras", "Day_Id");
            AddForeignKey("dbo.Paras", "Day_Id", "dbo.Days", "Id");
            DropColumn("dbo.Paras", "DaysId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paras", "DaysId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Paras", "Day_Id", "dbo.Days");
            DropIndex("dbo.Paras", new[] { "Day_Id" });
            DropColumn("dbo.Paras", "Day_Id");
            DropColumn("dbo.Paras", "DaId");
        }
    }
}
