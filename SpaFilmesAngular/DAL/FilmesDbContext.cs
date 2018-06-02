using SpaFilmesAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpaFilmesAngular.DAL
{
    public class FilmesDbContext:DbContext
    {
        public DbSet<Filmes> Filmes { get; set; }
    }
}