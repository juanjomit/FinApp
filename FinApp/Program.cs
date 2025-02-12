
using Business.Interfaces;
using Business.Services;
using Infraestructure.Contexts;
using Infraestructure.Interfaces;
using Infraestructure.Model;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FinApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DBContext
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddUserSecrets<Program>(true)
                .Build();

            string connectionString = config["FinApp_dev_Connection"];
            builder.Services.AddDbContext<FinAppContext>(options => options.UseSqlServer(connectionString));

            // Repositories
            builder.Services.AddScoped<IGenericRepository<BaseEntity, int>, GenericRepository<BaseEntity, int>>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Services
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FinAppContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

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
