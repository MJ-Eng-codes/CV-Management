using CV_Management.DTOs;
using System.Text.Json;

namespace CV_Management.EndPoints
{
    public class GitHubEndPoint
    {
        public static void RegisterEndPoints(WebApplication app)
        {
            app.MapGet("/users/{username}/github-repos", async (HttpClient client, string username, IConfiguration config) =>
            {
                // Use token if provided in the configuration
                var token = config["GitHubToken"];
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                // GitHub API requires User-Agent header
                client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp");

                //Get data from external API
                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest(new { message = "Error fetching data from GitHub API", statusCode = response.StatusCode });
                }

                // Parse Data and make into a list of RepositoriesDto
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var repositories = JsonSerializer.Deserialize<List<RepositoriesDto>>(json, options);

                // Handle empty or null responses
                if (repositories == null || repositories.Count == 0)
                {
                    return Results.NotFound(new { message = "No repositories found" });
                }

                return Results.Ok(repositories);
            });
        }
    }
}

