using CV_Management.DTOs;
using CV_Management.Services;

namespace CV_Management.EndPoints
{
    public class JobExperienceEndPoints
    {

        public static void RegisterEndPoints(WebApplication app)
        {
            app.MapGet("/jobs", async (JobExperienceService jobService) => await jobService.GetJobs());

            app.MapPost("/jobs/add", async (JobExperienceService jobService, JobsDto newJob) =>
            await jobService.AddJob(newJob));

            app.MapPut("/jobs/update", async (JobExperienceService jobService, JobsDto updateJob) =>
            await jobService.UpdateJob(updateJob));

            app.MapDelete("/jobs/delete", async (JobExperienceService jobService, int id) =>
            await jobService.RemoveJob(id));

        }
    }
}
