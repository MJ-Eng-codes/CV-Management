using CV_Management.DTOs;
using System.Text.Json;

namespace CV_Management.EndPoints
{
    public class GitHubEndPoint
    {
        public static void RegisterEndPoints(WebApplication app)
        {
            //MapGet/POST send Github username
            app.MapGet("/users/{username}/github-repos", async (HttpClient client, string username) =>
            {
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("MJ-Eng-Code"));

                //Get data from external API
                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");
                if (!response.IsSuccessStatusCode) return Results.BadRequest();



                //Parse Data
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<RepositoriesDto>(json, options);

                //Return Data
                return Results.Ok();
            });
        }

    }
}
