using CV_Management.Data;
using CV_Management.DTOs;
using CV_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Management.Services
{
    public class JobExperienceService
    {
        private readonly CVManageDBContext context;

        public JobExperienceService(CVManageDBContext context)
        {
            this.context = context;
        }

        public async Task<IResult> GetJobs()
        {
            try
            {
                var job = await context.JobExp
                .Select(j => new JobsDto
                {
                    JobID = j.JobID,
                    JobTitle = j.JobTitle,
                    Company = j.Company,
                    WorkDescription = j.WorkDescription,
                    Duration = j.Duration
                })
                .ToListAsync();

                return Results.Ok(job);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> AddJob(JobsDto newjob)
        {
            try
            {
                var user = await context.User
               .Where(u => u.UserID == newjob.UserId)
               .FirstOrDefaultAsync();

                if (user == null) return Results.NotFound("User not found!");

                var job = new JobExp
                {
                    UserID_Fk = newjob.UserId,
                    JobTitle = newjob.JobTitle,
                    Company = newjob.Company,
                    WorkDescription = newjob.WorkDescription,
                    Duration = newjob.Duration
                };

                context.Add(job);
                await context.SaveChangesAsync();

                return Results.Ok("Job added successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> UpdateJob(JobsDto updateJob)
        {
            try
            {
                var job = await context.JobExp
                .Where(j => j.JobID == updateJob.JobID)
                .FirstOrDefaultAsync();

                if (job == null) return Results.NotFound("Job with ID is not found");

                job.JobTitle = updateJob.JobTitle;
                job.Company = updateJob.Company;
                job.WorkDescription = updateJob.WorkDescription;
                job.Duration = updateJob.Duration;

                context.Update(job);
                await context.SaveChangesAsync();

                return Results.Ok("Existing Job has been updated succesfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }

        public async Task<IResult> RemoveJob(int id)
        {
            try
            {
                var job = await context.JobExp
                .Where(j => j.JobID == id)
                .FirstOrDefaultAsync();

                if (job == null) return Results.NotFound("Job Experience with ID is not found");

                context.JobExp.Remove(job);
                await context.SaveChangesAsync();

                return Results.Ok("Job Experience has been deleted successfully");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        }
    }
}
