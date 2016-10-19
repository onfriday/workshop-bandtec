using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkshopBandtecApp.Backend.Models;

namespace WorkshopBandtecApp.Backend.Controllers.API.v1
{
    [Authorize]
    [RoutePrefix("api/v1/musica")]
    public class Musica_v1Controller : ApiController
    {
        private readonly ApplicationDbContext _Context = ApplicationDbContext.Create();

        [Route()]
        public IEnumerable<Musica> Get()
        {
            return this._Context.Musicas.ToList();
        }

        // GET: api/Album_v1/5
        [Route("{id:guid}")]
        public Musica Get(Guid id)
        {
            return this._Context.Musicas.FirstOrDefault(lbda => lbda.Id == id);
        }

        // POST: api/Album_v1
        [Route()]
        [HttpPost]
        public Musica Post([FromBody]Musica value)
        {
            var _musica = this._Context.Musicas.FirstOrDefault(lbda => lbda.Id == value.Id);

            if (_musica == null)
            {
                _musica = new Musica()
                {
                    Duracao = value.Duracao,
                    Id = Guid.NewGuid(),
                    Nome = value.Nome,
                    Trilha = value.Trilha
                };

                this._Context.Musicas.Add(_musica);
            }
            else
            {
                _musica.Duracao = value.Duracao;
                _musica.Nome = value.Nome;
                _musica.Trilha = value.Trilha;
            }

            if (this._Context.ChangeTracker.HasChanges())
                this._Context.SaveChanges();

            return _musica;
        }

        // PUT: api/Album_v1/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Album_v1/5
        //public void Delete(int id)
        //{
        //}
    }
}
