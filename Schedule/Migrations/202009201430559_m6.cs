namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paras", "DaysId", c => c.Int());
            DropColumn("dbo.Paras", "DaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paras", "DaId", c => c.Int());
            DropColumn("dbo.Paras", "DaysId");
        }
    }
}
