using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FilmOpgave_WEXO.Domain.api
{
    public class ApiRequester
    {
        private readonly string? apiKey;
        private readonly string? apiReadAccessToken;
        private readonly string? baseUrl;
        private readonly RestClient restClient;


        //Initializes a new instance of the<see cref = "ApiRequester" /> class.

        // This constructor retrieves API credentials from environment variables and sets up the base URL for API requests.
        // It also initializes a <see cref="RestClient"/> instance to be used for making HTTP requests.


        public ApiRequester()
        {
            this.apiKey = Environment.GetEnvironmentVariable("API_KEY");
            this.apiReadAccessToken = Environment.GetEnvironmentVariable("API_READ_ACCESS_TOKEN");
            this.baseUrl = "https://api.themoviedb.org/3/"; 

            // Create a new RestClient with the base URL.
            // We set the options property to the base URL.
            var options = new RestClientOptions(baseUrl);
            this.restClient = new RestClient(options);
                }





        // Sends a GET request to the TMDb API and retrieves the JSON response.
        // <param name="movieId">The ID of the movie to fetch.</param>
        // Returns JSON response as a string.</returns>
        public async Task<string?> GetMovieAsync(int movieId)
        {
            var request = new RestRequest($"movie/{movieId}");

            // Set required headers
            request.AddHeader("accept", "application/json");

            if (!string.IsNullOrEmpty(apiReadAccessToken))
            {
                request.AddHeader("Authorization", $"Bearer {apiReadAccessToken}");
            }

            try
            {
                var response = await restClient.GetAsync(request);

                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    return null;
                }

                return response.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }


        // Fetches the list of movie genres from the TMDb API.  
        // Returns a JSON string containing the genre list if successful; otherwise, returns null.

        // This method sends a GET request to the "genre/movie/list" endpoint of the TMDb API.
        // <exception cref="HttpRequestException">
        // Thrown if the request encounters an issue (e.g., network failure).
        public async Task<string?> GetGenresAsync()
        {
            var request = new RestRequest("genre/movie/list");
            // Set required headers
            request.AddHeader("accept", "application/json");
            if (!string.IsNullOrEmpty(apiReadAccessToken))
            {
                request.AddHeader("Authorization", $"Bearer {apiReadAccessToken}");
            }
            try
            {
                var response = await restClient.GetAsync(request);
                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    return null;
                }
                return response.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }


        // Retrieves a list of movies that belong to a specific genre from the TMDb API.

        // <param name="genreid">The ID of the genre to filter movies by.</param>
        // <param name="page">The page number for pagination (defaults to 1).</param>

        // Returns a JSON string containing the list of movies if successful; otherwise, returns null.

        // This method sends a GET request to the `discover/movie` endpoint of the TMDb API.
        // It filters movies based on the specified genre ID and supports pagination.
        // The request includes the necessary headers, including an authorization token.

        // <exception cref="HttpRequestException">
        // Thrown if the request encounters an issue (e.g., network failure or invalid response).
        public async Task<string?> GetMoviesByGenre(int genreid, int? page = 1)
        {
            var request = new RestRequest($"discover/movie?with_genres={genreid}&page={page}");

            // Set required headers
            request.AddHeader("accept", "application/json");
            if (!string.IsNullOrEmpty(apiReadAccessToken))
            {
                request.AddHeader("Authorization", $"Bearer {apiReadAccessToken}");
            }

            try
            {
                var response = await restClient.GetAsync(request);
                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                    return null;
                }
                return response.Content;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }



        }
    }

}
