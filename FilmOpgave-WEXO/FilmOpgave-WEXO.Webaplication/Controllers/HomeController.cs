using FilmOpgave_WEXO.Webaplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FilmOpgave_WEXO.Domain.Controllers;

namespace FilmOpgave_WEXO.Webaplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MovieController movieController;
        private readonly GenreController genreController;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.movieController = new MovieController();
            this.genreController = new GenreController();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Displays a list of genres.
        public async Task<IActionResult> Genres()
        {
            var genres = await genreController.FetchGenresAsync();
            var genreMovieCounts = new Dictionary<int, int>();

            foreach (var genre in genres)
            {
                var movies = await movieController.FetchMoviesByGenreAsync(genre.Id);
                genreMovieCounts[genre.Id] = movies.Count; // Store movie count for each genre
            }

            var viewModel = new GenreViewModel
            {
                Genres = genres,
                GenreMovieCounts = genreMovieCounts
            };

            return View(viewModel);


        }

        // Displays movies by genre.
        public async Task<IActionResult> MoviesByGenre(int genreId)
        {
            var movies = await movieController.FetchMoviesByGenreAsync(genreId);
            return View(movies);
        }

        // Displays details of a movie by ID.
        public async Task<IActionResult> MovieDetails(int movieId)
        {
            var movie = await movieController.FetchMovieAsync(movieId);
            return View(movie);
        }

        // Returns a JSON list of genres.
        public async Task<IActionResult> GenresJson()
        {
            var genres = await genreController.FetchGenresAsync();
            return Json(genres);
        }


    }
}
