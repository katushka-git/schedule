namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropColumn("dbo.Teachers", "SubjectId");
            DropColumn("dbo.Teachers", "PositionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "PositionId", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "PositionId");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
    }
}
