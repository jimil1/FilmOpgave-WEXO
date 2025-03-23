using FilmOpgave_WEXO.Domain;

namespace FilmOpgave_WEXO.Webaplication.VeiwModels

{

    public class GenreViewModel
    {
        public List<Genre> Genres { get; set; }
        public Dictionary<int, int> GenreMovieCounts { get; set; }
        public GenreViewModel(Dictionary<int, int> GenreMovieCounts, List<Genre> Genres) {
        
        this.GenreMovieCounts = GenreMovieCounts;
        this.Genres = Genres;

        }
        
    }
}
