namespace SpaFilmesAngular.Migrations
{
    using SpaFilmesAngular.DAL;
    using SpaFilmesAngular.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaFilmesAngular.DAL.FilmesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FilmesDbContext context)
        {
            context.Filmes.AddOrUpdate(m => m.Titulo, new Filmes { Titulo="Star Wars",AnoLancameto=1977,Duracao=121},
                new Filmes { Titulo="Inception",AnoLancameto=2010,Duracao=148},
                new Filmes { Titulo="Toy Story",AnoLancameto=1995,Duracao=81});

        }
    }
}
