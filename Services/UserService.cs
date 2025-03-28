using CV_Management.Data;
using CV_Management.DTOs;
using CV_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Management.Services
{
    public class UserService
    {
        private readonly CVManageDBContext context;

        public UserService(CVManageDBContext context)
        {
            this.context = context;
        }

        public async Task<IResult> GetAllUsers()
        {
            try
            {
                var userList = await context.User
                .Select(s => new UserDto
                {
                    Name = s.Name,
                    Description = s.Description,
                    Email = s.Email,
                    Education = s.Education.Select(e => new EducationDto
                    {
                        EduID = e.EduID,
                        School = e.School,
                        Degree = e.Degree,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate
                    }).ToList(),
                    JobExp = s.JobExp.Select(j => new JobsDto
                    {
                        JobID = j.JobID,
                        JobTitle = j.JobTitle,
                        Company = j.Company,
                        WorkDescription = j.WorkDescription,
                        Duration = j.Duration

                    }).ToList()
                })
                .ToListAsync();

                return Results.Ok(userList);
            }
            catch (Exception ex)
            {
                return Results.Ok(ex.Message);
            }
        }

        public async Task<IResult> GetUser(int id)
        {
            try
            {
                var user = await context.User
                .Where(u => u.UserID == id)
                .FirstOrDefaultAsync();

                if (user == null) return Results.NotFound("User with id is not found");

                var existingUser = await context.User
                    .Where(u => u.UserID == id)
                    .Select(u => new UserDto
                    {
                        Name = u.Name,
                        Description = u.Description,
                        Email = u.Email,
                        Education = u.Education.Select(e => new EducationDto
                        {
                            EduID = e.EduID,
                            School = e.School,
                            Degree = e.Degree,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate
                        }).ToList(),
                        JobExp = u.JobExp.Select(j => new JobsDto
                        {
                            JobID = j.JobID,
                            JobTitle = j.JobTitle,
                            Company = j.Company,
                            WorkDescription = j.WorkDescription,
                            Duration = j.Duration

                        }).ToList()

                    })
                    .ToListAsync();

                return Results.Ok(user);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> UpdateUser(UserDto updateUser, int id)
        {
            try
            {
                var user = await context.User
               .Where(u => u.UserID == id)
               .FirstOrDefaultAsync();

                if (user == null) return Results.NotFound("User with id is not found");

                user.Name = updateUser.Name;
                user.Description = updateUser.Description;
                user.Email = updateUser.Email;

                context.Update(updateUser);
                await context.SaveChangesAsync();

                return Results.Ok("User has been updated");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> CreateUser(UserDto user)
        {
            try
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Description = user.Description,
                    Email = user.Email
                };
                context.Add(newUser);
                await context.SaveChangesAsync();

                return Results.Ok("New user created successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
