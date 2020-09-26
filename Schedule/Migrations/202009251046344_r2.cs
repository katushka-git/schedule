namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Paras", name: "Day_Id", newName: "DayId");
            RenameIndex(table: "dbo.Paras", name: "IX_Day_Id", newName: "IX_DayId");
            DropColumn("dbo.Paras", "DaysId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paras", "DaysId", c => c.Int());
            RenameIndex(table: "dbo.Paras", name: "IX_DayId", newName: "IX_Day_Id");
            RenameColumn(table: "dbo.Paras", name: "DayId", newName: "Day_Id");
        }
    }
}
