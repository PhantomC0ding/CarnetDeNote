using CarnetDeNote;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfiguration(builder);
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IMeniuInteractiv, MeniuInteractiv>();
            })
            .UseSerilog()
            .Build();
        
        var svc=ActivatorUtilities.CreateInstance<MeniuInteractiv>(host.Services);
        svc.Execute();
    }
    
    static void BuildConfiguration(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?? "Production"} .json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}

