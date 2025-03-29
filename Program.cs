
using CV_Management.Data;
using CV_Management.EndPoints;
using CV_Management.Services;
using Microsoft.EntityFrameworkCore;

namespace CV_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Connecting to database
            builder.Services.AddDbContext<CVManageDBContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Invoke External API
            builder.Services.AddHttpClient();

            //To register userService
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<EducationService>();
            builder.Services.AddScoped<JobExperienceService>();
           



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            EducationEndPoints.RegisterEndPoints(app);
            JobExperienceEndPoints.RegisterEndPoints(app);
            UserEndPoints.RegisterEndPoints(app);


            GitHubEndPoint.RegisterEndPoints(app);

            app.Run();
        }
    }
}
