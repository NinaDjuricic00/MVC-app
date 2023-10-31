namespace Pojekat3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Peti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Raspolaze", "StatusRaspolozivosti", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Raspolaze", "StatusRaspolozivosti");
        }
    }
}
