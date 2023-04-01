using Autofac.Extensions.DependencyInjection;
using Autofac;
using AppZJOHotel.Services;
using AppZJOHotel.Services.GuestService;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AppZJOHotel.WEBAPI.Db_Access;
using System.Reflection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        // In ASP.NET Core 3.x, using `Host.CreateDefaultBuilder` (as in the preceding Program.cs snippet) will
        // set up some configuration for you based on your appsettings.json and environment variables. See "Remarks" at
        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder for details.
        this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; private set; }

    public ILifetimeScope AutofacContainer { get; private set; }

    // ConfigureServices is where you register dependencies. This gets
    // called by the runtime before the ConfigureContainer method, below.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the collection. Don't build or return
        // any IServiceProvider or the ConfigureContainer method
        // won't get called. Don't create a ContainerBuilder
        // for Autofac here, and don't call builder.Populate() - that
        // happens in the AutofacServiceProviderFactory for you.

        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
        Configuration.GetConnectionString("HotelConnection")));

        services.AddMvc();
        //services.AddScoped<ServiceModule>();
        //services.AddScoped<IGuestService, GuestService>();
        services.AddControllers();

        services.AddSwaggerGen();
        services.AddSwaggerDocument();

        services.AddOptions();
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Register your own things directly with Autofac here. Don't
        // call builder.Populate(), that happens in AutofacServiceProviderFactory
        // for you.
        
        builder.RegisterModule(new ServiceModule());

        //builder.Register(x =>
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("HotelConnection"));
        //    return new DatabaseContext(optionsBuilder.Options);
        //}).InstancePerLifetimeScope();
    }

    // Configure is where you add middleware. This is called after
    // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
    // here if you need to resolve things from the container.
    public void Configure(
      IApplicationBuilder app,
      ILoggerFactory loggerFactory)
    {
        // If, for some reason, you need a reference to the built container, you
        // can use the convenience extension method GetAutofacRoot.
        this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

        //loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
        //loggerFactory.AddDebug();
        //Microsoft.AspNetCore.Builder.SwaggerBuilderExtensions.UseSwagger(app, opt => opt.SwaggerDoc("v1", new Swashbuckle.AspNetCore.OpenApiInfo { Title = "My API", Version = "v1" }));
        //app.UseSwagger();
        // middleware do swagger-ui (HTML, JS, CSS, etc.),
        // tutaj określasz endpoint dla Swagger JSON
        //app.UseSwaggerUI();
        app.UseOpenApi();
        app.UseSwaggerUi3();
        //app.UseMvc();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}