namespace WorkshopBandtecApp.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBandTecSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Musica",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Trilha = c.String(),
                        Nome = c.String(),
                        Duracao = c.String(),
                        AlbumId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Ano = c.String(),
                        ArtistaId = c.Guid(nullable: false),
                        GeneroId = c.Guid(nullable: false),
                        Capa = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artista", t => t.ArtistaId, cascadeDelete: true)
                .ForeignKey("dbo.Genero", t => t.GeneroId, cascadeDelete: true)
                .Index(t => t.ArtistaId)
                .Index(t => t.GeneroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musica", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Album", "ArtistaId", "dbo.Artista");
            DropIndex("dbo.Album", new[] { "GeneroId" });
            DropIndex("dbo.Album", new[] { "ArtistaId" });
            DropIndex("dbo.Musica", new[] { "AlbumId" });
            DropTable("dbo.Album");
            DropTable("dbo.Musica");
            DropTable("dbo.Genero");
            DropTable("dbo.Artista");
        }
    }
}
