using AppZJOHotel.WEBAPI.Db_Access;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AppZJOHotel.Services;

namespace AppZJOHotel.WEBAPI;

public class Startup
{
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureForwardedHeaders(services);
        //ConfigureDatabase(services);
        //ConfigureOpenApiServices(services);

    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        try
        {
            builder.RegisterType<DatabaseContext>().InstancePerDependency().ExternallyOwned();
            //builder.RegisterType<ReadonlyDatabaseContext>().InstancePerDependency().ExternallyOwned();
            builder.RegisterModule<ServiceModule>();
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json", true);
            //var configurationModule = new Autofac.Configuration.ConfigurationModule(config.Build());
            //builder.RegisterModule(configurationModule);
        }
        catch (Exception e)
        {
            logger.Fatal(e, "ConfigureContainer");
            throw;
        }
    }
    private static void ConfigureForwardedHeaders(IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });
    }
    private static void ConfigureOpenApi(IApplicationBuilder app)
    {
        //app.UseOpenApi();
        //app.UseSwaggerUi3();
    }
}

