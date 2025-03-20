using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FilmOpgave_WEXO.Domain
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id")]
        public string Name { get; set; }

    }
}