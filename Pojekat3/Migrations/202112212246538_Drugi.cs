namespace Pojekat3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drugi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drogerija", "BrojTelefona", c => c.String(maxLength: 10));
            AlterColumn("dbo.Drogerija", "PIB", c => c.String(maxLength: 9));
            AlterColumn("dbo.Proizvod", "SifraProizvoda", c => c.String(maxLength: 23));
            AlterColumn("dbo.Proizvod", "OpisProizvoda", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvod", "OpisProizvoda", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Proizvod", "SifraProizvoda", c => c.String(nullable: false, maxLength: 23));
            AlterColumn("dbo.Drogerija", "PIB", c => c.String(nullable: false, maxLength: 9));
            DropColumn("dbo.Drogerija", "BrojTelefona");
        }
    }
}
