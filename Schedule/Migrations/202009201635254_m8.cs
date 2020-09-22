namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teachers", "PositionId", c => c.Int());
            AddColumn("dbo.Teachers", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Teachers", "PositionId");
            CreateIndex("dbo.Teachers", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id");
            DropColumn("dbo.Teachers", "Position");
            DropColumn("dbo.Teachers", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Department", c => c.String());
            AddColumn("dbo.Teachers", "Position", c => c.String());
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropColumn("dbo.Teachers", "DepartmentId");
            DropColumn("dbo.Teachers", "PositionId");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
        }
    }
}
