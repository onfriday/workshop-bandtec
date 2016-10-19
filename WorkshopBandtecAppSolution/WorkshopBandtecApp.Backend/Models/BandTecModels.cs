using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopBandtecApp.Backend.Models
{
    public abstract class BandTecBase<TBase>
    {
        [Key]
        public Guid Id { get; set; }
    }

    [Table("Artista")]
    public class Artista : BandTecBase<Artista>
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
    }

    [Table("Genero")]
    public class Genero : BandTecBase<Genero>
    {
        public string Nome { get; set; }
    }

    [Table("Album")]
    public class Album : BandTecBase<Album>
    {
        public string Nome { get; set; }
        public string Ano { get; set; }

        [Required]
        public Guid ArtistaId { get; set; }

        [ForeignKey("ArtistaId")]
        public virtual Artista Artista { get; set; }

        [Required]
        public Guid GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }

        public string Capa { get; set; }
    }

    [Table("Musica")]
    public class Musica : BandTecBase<Musica>
    {
        public string Trilha { get; set; }
        public string Nome { get; set; }

        public string Duracao { get; set; }

        //[Required]
        //public Guid AlbumId { get; set; }

        //[ForeignKey("AlbumId")]
        //public virtual Album Album { get; set; }
    }
}
