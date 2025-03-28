using CV_Management.DTOs;
using CV_Management.Services;

namespace CV_Management.EndPoints

{
    public class EducationEndPoints
    {

        public static void RegisterEndPoints(WebApplication app)
        {
            app.MapGet("/educations", async (EducationService educationService) => await educationService.GetEducationsAsync());

            app.MapPost("/educations/add", async (EducationService educationService, EducationDto newEducation) =>
            await educationService.AddEducation(newEducation));

            app.MapPut("/educations/update", async (EducationService educationService, EducationDto updateEducation) =>
            await educationService.UpdateEducation(updateEducation));

            app.MapDelete("/educations/delete/{eduid}", async (EducationService educationService, int eduid) =>
            await educationService.RemoveEducation(eduid));

        }

    }
}
