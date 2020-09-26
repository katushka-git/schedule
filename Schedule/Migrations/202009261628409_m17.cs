namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m17 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UPlans", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UPlans", "Total", c => c.Int(nullable: false));
        }
    }
}
