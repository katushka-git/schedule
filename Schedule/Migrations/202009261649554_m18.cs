namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans");
            DropIndex("dbo.Subjects", new[] { "UPlanId" });
            AddColumn("dbo.UPlans", "Labor", c => c.Int(nullable: false));
            AddColumn("dbo.UPlans", "Zachet", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "UPlanId", c => c.Int(nullable: true));
            CreateIndex("dbo.Subjects", "UPlanId");
            AddForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans", "Id", cascadeDelete: true);
            DropColumn("dbo.UPlans", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UPlans", "SubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans");
            DropIndex("dbo.Subjects", new[] { "UPlanId" });
            AlterColumn("dbo.Subjects", "UPlanId", c => c.Int());
            DropColumn("dbo.UPlans", "Zachet");
            DropColumn("dbo.UPlans", "Labor");
            CreateIndex("dbo.Subjects", "UPlanId");
            AddForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans", "Id");
        }
    }
}
