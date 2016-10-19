namespace WorkshopBandtecApp.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAlbumFKMusica : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "ArtistaId", "dbo.Artista");
            DropForeignKey("dbo.Album", "GeneroId", "dbo.Genero");
            DropForeignKey("dbo.Musica", "AlbumId", "dbo.Album");
            DropIndex("dbo.Musica", new[] { "AlbumId" });
            DropIndex("dbo.Album", new[] { "ArtistaId" });
            DropIndex("dbo.Album", new[] { "GeneroId" });
            DropColumn("dbo.Musica", "AlbumId");
            DropTable("dbo.Album");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Musica", "AlbumId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Album", "GeneroId");
            CreateIndex("dbo.Album", "ArtistaId");
            CreateIndex("dbo.Musica", "AlbumId");
            AddForeignKey("dbo.Musica", "AlbumId", "dbo.Album", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Album", "GeneroId", "dbo.Genero", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Album", "ArtistaId", "dbo.Artista", "Id", cascadeDelete: true);
        }
    }
}
