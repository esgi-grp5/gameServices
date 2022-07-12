using System.Text.Json;

namespace gameServices.Models
{
    public class TmdbApiObject
    {
        public int page { get; set; }
        public List<JsonElement> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

    }
}
