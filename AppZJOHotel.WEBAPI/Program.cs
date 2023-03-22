//using AppZJOHotel.WEBAPI.Db_Access;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("HotelConnection")));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using AppZJOHotel.WEBAPI;
using Autofac.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        // ASP.NET Core 3.0+:
        // The UseServiceProviderFactory call attaches the
        // Autofac provider to the generic hosting mechanism.
        var host = Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webHostBuilder => {
                webHostBuilder
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>();
            })
            .Build();

        host.Run();
    }
}