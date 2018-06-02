using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SpaFilmesAngular.DAL;
using SpaFilmesAngular.Models;

namespace SpaFilmesAngular.Controllers
{
    public class FilmeController : ApiController
    {
        private FilmesDbContext db = new FilmesDbContext();

        // GET: api/Filme
        public IHttpActionResult GetFilmes()
        {
            return Ok(db.Filmes);
        }

        // GET: api/Filme/5
        [ResponseType(typeof(Filmes))]
        public IHttpActionResult GetFilmes(int id)
        {
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return NotFound();
            }

            return Ok(filmes);
        }

        // PUT: api/Filme/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilmes(int id, Filmes filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filmes.Id)
            {
                return BadRequest();
            }

            db.Entry(filmes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Filme
        [ResponseType(typeof(Filmes))]
        public IHttpActionResult PostFilmes(Filmes filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filmes.Add(filmes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = filmes.Id }, filmes);
        }

        // DELETE: api/Filme/5
        [ResponseType(typeof(Filmes))]
        public IHttpActionResult DeleteFilmes(int id)
        {
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return NotFound();
            }

            db.Filmes.Remove(filmes);
            db.SaveChanges();

            return Ok(filmes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmesExists(int id)
        {
            return db.Filmes.Count(e => e.Id == id) > 0;
        }
    }
}