namespace Pojekat3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prvi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drogerija",
                c => new
                    {
                        DrogerijaID = c.Int(nullable: false, identity: true),
                        Adresa = c.String(nullable: false, maxLength: 30),
                        Naziv = c.String(nullable: false, maxLength: 15),
                        PIB = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.DrogerijaID);
            
            CreateTable(
                "dbo.Raspolaze",
                c => new
                    {
                        RaspolazeID = c.Int(nullable: false, identity: true),
                        Kolicina = c.Int(nullable: false),
                        CenaProizvoda = c.Int(nullable: false),
                        ProizvodID = c.Int(nullable: false),
                        DrogerijaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaspolazeID)
                .ForeignKey("dbo.Drogerija", t => t.DrogerijaID, cascadeDelete: true)
                .ForeignKey("dbo.Proizvod", t => t.ProizvodID, cascadeDelete: true)
                .Index(t => t.ProizvodID)
                .Index(t => t.DrogerijaID);
            
            CreateTable(
                "dbo.Proizvod",
                c => new
                    {
                        ProizvodID = c.Int(nullable: false, identity: true),
                        SifraProizvoda = c.String(nullable: false, maxLength: 23),
                        NazivProizvoda = c.String(nullable: false, maxLength: 30),
                        OpisProizvoda = c.String(nullable: false, maxLength: 500),
                        NabavnaCenaProizvoda = c.Int(nullable: false),
                        ProdajnaCenaProizvoda = c.Int(nullable: false),
                        TipProizvodaID = c.Int(nullable: false),
                        ZemljaUvozaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodID)
                .ForeignKey("dbo.TipProizvoda", t => t.TipProizvodaID, cascadeDelete: true)
                .ForeignKey("dbo.ZemljaUvoza", t => t.ZemljaUvozaID, cascadeDelete: true)
                .Index(t => t.TipProizvodaID)
                .Index(t => t.ZemljaUvozaID);
            
            CreateTable(
                "dbo.TipProizvoda",
                c => new
                    {
                        TipProizvodaID = c.Int(nullable: false, identity: true),
                        Vrsta = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.TipProizvodaID);
            
            CreateTable(
                "dbo.ZemljaUvoza",
                c => new
                    {
                        ZemljaUvozaID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => t.ZemljaUvozaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proizvod", "ZemljaUvozaID", "dbo.ZemljaUvoza");
            DropForeignKey("dbo.Proizvod", "TipProizvodaID", "dbo.TipProizvoda");
            DropForeignKey("dbo.Raspolaze", "ProizvodID", "dbo.Proizvod");
            DropForeignKey("dbo.Raspolaze", "DrogerijaID", "dbo.Drogerija");
            DropIndex("dbo.Proizvod", new[] { "ZemljaUvozaID" });
            DropIndex("dbo.Proizvod", new[] { "TipProizvodaID" });
            DropIndex("dbo.Raspolaze", new[] { "DrogerijaID" });
            DropIndex("dbo.Raspolaze", new[] { "ProizvodID" });
            DropTable("dbo.ZemljaUvoza");
            DropTable("dbo.TipProizvoda");
            DropTable("dbo.Proizvod");
            DropTable("dbo.Raspolaze");
            DropTable("dbo.Drogerija");
        }
    }
}
