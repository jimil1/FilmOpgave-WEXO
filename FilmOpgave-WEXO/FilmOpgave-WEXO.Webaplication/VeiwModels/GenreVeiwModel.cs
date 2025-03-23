using FilmOpgave_WEXO.Domain.Models;

namespace FilmOpgave_WEXO.Webaplication.VeiwModels

{
    public class GenreViewModel
    {
        public List<Genre> Genres { get; set; }
        public Dictionary<int, int> GenreMovieCounts { get; set; }
    }
}
