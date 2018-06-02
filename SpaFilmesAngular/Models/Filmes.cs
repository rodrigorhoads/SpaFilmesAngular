using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaFilmesAngular.Models
{
    public class Filmes
    {
        public int Id{ get; set; }
        public string Titulo { get; set; }
        public int AnoLancameto { get; set; }
        public int Duracao { get; set; }
    }
}