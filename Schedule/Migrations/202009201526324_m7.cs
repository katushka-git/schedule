namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "TeacherId", c => c.Int());
            AddColumn("dbo.Teachers", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "TeacherId");
            AddForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers", "Id");
            DropColumn("dbo.Teachers", "Subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Subject", c => c.String());
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropColumn("dbo.Teachers", "SubjectId");
            DropColumn("dbo.Subjects", "TeacherId");
        }
    }
}
