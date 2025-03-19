using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmOpgave_WEXO.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public List<string> Actors { get; set; }

        public string PosterPath { get; set; }

        public List<Grenre> Grenres { get; set; }


    }
}
