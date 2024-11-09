using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebAPICars.Context;
using WebAPICars.Repositories.Implementations;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Implementations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
            builder.Services.AddScoped<IOwnerService, OwnerService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddControllers();

            // Configure CORS
            // Configure CORS for Blazor WebAssembly
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorApp", builder =>
                    builder.WithOrigins("http://localhost:5248") // URL of your Blazor WebAssembly app
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials());
            });


            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); // Optional: Use HTTPS in production

            app.UseAuthorization();

            app.UseCors("AllowBlazorApp"); // Ensure this is before MapControllers

            app.MapControllers();

            app.Run();
        }
    }
}
