
using NiftyCoders.Services.TraineeManagement.Business.Services;
using NiftyCoders.Services.TraineeManagement.Persistence.Repositories;
using NiftyCoders.Services.TraineeManagement.Middlewares;


namespace NiftyCoders.Services.TraineeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //dependency injections
            builder.Services.AddScoped<ITraineeServices, TraineeServices>();


            builder.Services.AddScoped<TraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<UniversityRepository, UniversityRepository>();
            builder.Services.AddScoped<TrainningPeriodRepository, TrainningPeriodRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
