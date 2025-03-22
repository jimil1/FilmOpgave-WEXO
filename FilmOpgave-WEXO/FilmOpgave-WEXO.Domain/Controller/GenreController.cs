using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using FilmOpgave_WEXO.Domain.api;


namespace FilmOpgave_WEXO.Domain.Controller
{
    public class GenreController
    {
        private ApiRequester apiRequester;

        public GenreController()
        {
            this.apiRequester = new ApiRequester();
        }

        // Fetches and deserializes genres from the TMDb API.
      
        // <returns>A list of Genre objects.</returns>
        public async Task<List<Genre>> FetchGenresAsync()
        {
            string? jsonResponse = await this.apiRequester.GetGenresAsync();
            if (string.IsNullOrEmpty(jsonResponse))
            {
                Console.WriteLine("Failed to fetch genres.");
                return new List<Genre>();
            }
            try
            {
                var genreData = JsonSerializer.Deserialize<GenreResponse>(jsonResponse);
                return genreData?.Genres ?? new List<Genre>();
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON Parsing Error: {e.Message}");
                return new List<Genre>();
            }
        }
        // Helper class for genre API response.
        internal class GenreResponse
        {
            [JsonPropertyName("genres")]
            public List<Genre> Genres { get; set; }
        }
    }
}
