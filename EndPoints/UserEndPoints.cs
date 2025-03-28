using CV_Management.DTOs;
using CV_Management.Services;

namespace CV_Management.EndPoints
{
    public class UserEndPoints
    {
        public static void RegisterEndPoints(WebApplication app)
        {
            app.MapGet("/users", async (UserService userService) =>
                await userService.GetAllUsers());

            app.MapGet("/users/{id}", async (UserService userService, int id) =>
                await userService.GetUser(id));

            app.MapPut("/users/{id}/update", async (UserService userService, UserDto updateUser, int id) =>
                await userService.UpdateUser(updateUser, id));

            app.MapPost("users/create", async (UserService userService, UserDto createUser) =>
                await userService.CreateUser(createUser));
        }
    }
}
