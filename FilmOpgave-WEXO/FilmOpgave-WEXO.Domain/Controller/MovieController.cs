using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MovieModel.api;
using MovieModel.models;

namespace FilmOpgave_WEXO.Domain.Controller
{
    class MovieController
    {
        private ApiRequster apiRequster;

        public MovieController()
        {
            this.apiRequster = new ApiRequster();
        }

        //Fetches and deserializes a single movie by ID
        // <param name="movieId">The ID of the movie.</param>
        // <returns>A Movie object or null if not found.</returns>
        public async Task<Movie?> FetchMovieAsync(int movieId)
        {
            string? jsonResponse = await this.apiRequster.getMocieAsync(movieId);
            if (string.IsNullOrEmpty(jsonResponse))
            {
                Console.WriteLine($"Failed to fetch movie with ID {movieId}.");
                return null;
            }
            try
            {
                return JsonSerializer.Deserialize<Movie>(jsonResponse);
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
                return null;
            }
        }

        // Fetches and deserializes movies sorted by genre.
        // </summary>
        // <param name="genreId">The ID of the genre.</param>
        // <returns>A list of Movie objects.</returns>
        public async Task<List<Movie>> fetchMoviesByGrenreAsync(int genreId)
        {
            string? jasonResponse = await this.apiRequster.getMoviesByGrenre(genreId);

            if (string.IsnullOrEmpty(jsonResponse))
            {
                Console.WriteLine($"Failed to fetch movies for genre {genreId}.");
                return new List<Movie>();
            }
            try
            {
                var movieData = JsonSerializer.Deserialize<MovieListResponse>(jsonResponse);
                return movieData?.Results ?? new List<Movie>();
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
                return new List<Movie>();
            }


        }
        // Helper class for movie list API response.
        internal class MovieListResponse
        {
            [JsonPropertyName("results")]
            public List<Movie> Results { get; set; }
        }
    }
}
