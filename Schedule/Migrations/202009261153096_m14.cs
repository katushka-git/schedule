namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            AlterColumn("dbo.Teachers", "PositionId", c => c.Int(nullable: true));
            AlterColumn("dbo.Teachers", "DepartmentId", c => c.Int(nullable: true));
            CreateIndex("dbo.Teachers", "PositionId");
            CreateIndex("dbo.Teachers", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            AlterColumn("dbo.Teachers", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Teachers", "PositionId", c => c.Int());
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.Teachers", "PositionId");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id");
        }
    }
}
