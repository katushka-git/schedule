namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CallShedules", "Start", c => c.Double(nullable: false));
            AlterColumn("dbo.CallShedules", "Finish", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CallShedules", "Finish", c => c.Int(nullable: false));
            AlterColumn("dbo.CallShedules", "Start", c => c.Int(nullable: false));
        }
    }
}
