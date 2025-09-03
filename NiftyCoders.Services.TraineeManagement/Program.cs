
using Microsoft.EntityFrameworkCore;
using NiftyCoders.Services.TraineeManagement.Business.TraineeServices;
using NiftyCoders.Services.TraineeManagement.Middlewares;
using NiftyCoders.Services.TraineeManagement.Persistence;


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


            builder.Services
                .AddScoped<ITraineeFetcher, TraineeFetcher>()
                .AddScoped<ITraineeCreator, TraineeCreator>()
                .AddScoped<ITraineeUpdate, TraineeUpdate>()
                .AddScoped<ITraineeDelete, TraineeDelete>();



            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

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
