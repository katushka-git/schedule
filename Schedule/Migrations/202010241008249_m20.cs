namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UPlans", "NameSubject", c => c.String());
            DropColumn("dbo.Subjects", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Name", c => c.String());
            DropColumn("dbo.UPlans", "NameSubject");
        }
    }
}
