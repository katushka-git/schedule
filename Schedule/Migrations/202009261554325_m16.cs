namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "PositionId", c => c.Int(nullable: true));
            CreateIndex("dbo.Teachers", "PositionId");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropColumn("dbo.Teachers", "PositionId");
        }
    }
}
