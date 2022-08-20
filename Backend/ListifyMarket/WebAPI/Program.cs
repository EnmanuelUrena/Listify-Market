using Application.Common.Interfaces;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ConfigureService.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

            //Create my own ServiceConfiguration
            IServiceCollection services = new ServiceCollection();
            services.ConfigureServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Generate seed data
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}