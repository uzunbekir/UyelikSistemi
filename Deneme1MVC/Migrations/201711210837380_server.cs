namespace Deneme1MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class server : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        DersId = c.Int(nullable: false, identity: true),
                        DersAdi = c.String(),
                    })
                .PrimaryKey(t => t.DersId);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        DersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ders", t => t.DersId, cascadeDelete: true)
                .Index(t => t.DersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "DersId", "dbo.Ders");
            DropIndex("dbo.Ogrencis", new[] { "DersId" });
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Ders");
        }
    }
}
