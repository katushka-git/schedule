namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Lecture = c.Int(nullable: false),
                        Control = c.Int(nullable: false),
                        Practical = c.Int(nullable: false),
                        Coursework = c.Int(nullable: false),
                        Exam = c.Int(nullable: false),
                        Consultation = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UPlans");
        }
    }
}
