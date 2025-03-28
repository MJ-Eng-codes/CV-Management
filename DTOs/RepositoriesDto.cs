using System.Text.Json.Serialization;

namespace CV_Management.DTOs
{
    public class RepositoriesDto
    {
     
        public string Name { get; set; }

        public string? Language { get; set; }

        public string? Description { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
    }
}
