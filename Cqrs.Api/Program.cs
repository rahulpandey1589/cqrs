using Cqrs.Shared.Settings;
using Cqrs.Infrastructure;

namespace Cqrs.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // AutoMapper:

            var @assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in @assemblies.Where(x => x.FullName.StartsWith("Cqrs"))) { Console.WriteLine(assembly); }

            builder.Services.AddAutoMapper(assemblies);

            // MediatR:
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


            builder.Services.Configure<DbSettingModel>(builder.Configuration.GetSection(nameof(DbSettingModel)));

            builder.Services.AddInfrastructureServices(builder.Configuration);


            // Add services to the container.


            var app = builder.Build();

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
