


using CV_Management.Data;
using CV_Management.DTOs;
using CV_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace CV_Management.Services
{
    public class EducationService
    {
        private readonly CVManageDBContext context;

        public EducationService(CVManageDBContext context)
        {
            this.context = context;
        }

        public async Task<IResult> GetEducationsAsync()
        {
            try
            {
                var educations = await context.Education
                    .Select(e => new EducationDto
                    {
                        School = e.School,
                        Degree = e.Degree,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate
                    }).ToListAsync();

                return Results.Ok(educations);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        }

        public async Task<IResult> AddEducation(EducationDto newEducation)
        {
            try
            {
                var user = await context.User
                    .Where(u => u.UserID == newEducation.EduID)
                    .FirstOrDefaultAsync();

                if (user == null) return Results.NotFound("User not found!");

                var education = new Education
                {
                    UserID_Fk = newEducation.EduID,
                    School = newEducation.School,
                    Degree = newEducation.Degree,
                    StartDate = newEducation.StartDate,
                    EndDate = newEducation.EndDate
                };

                context.Education.Add(education);
                await context.SaveChangesAsync();

                return Results.Ok("Education added successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> UpdateEducation(EducationDto updateEducation)
        {
            try
            {
                var education = await context.Education
                     .Where(e => e.EduID == updateEducation.EduID)
                     .FirstOrDefaultAsync();

                if (education == null) return Results.NotFound("Education with ID is not found");

                education.School = updateEducation.School;
                education.Degree = updateEducation.Degree;
                education.StartDate = updateEducation.StartDate;
                education.EndDate = updateEducation.EndDate;

                context.Education.Update(education);
                await context.SaveChangesAsync();

                return Results.Ok("Education is updated successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> RemoveEducation(int id)
        {
            try
            {
                var education = await context.Education
                    .Where(e => e.EduID == id)
                    .FirstOrDefaultAsync();

                if (education == null) return Results.NotFound("Education with ID is not found");

                context.Education.Remove(education);
                await context.SaveChangesAsync();

                return Results.Ok("Education is deleted successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        }
    }
}
