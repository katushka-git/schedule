namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "UPlanId", c => c.Int());
            CreateIndex("dbo.Subjects", "UPlanId");
            AddForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "UPlanId", "dbo.UPlans");
            DropIndex("dbo.Subjects", new[] { "UPlanId" });
            DropColumn("dbo.Subjects", "UPlanId");
        }
    }
}
