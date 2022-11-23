using Otvetmailru.WebAPI.AppConfiguration.ApplicationExtensions;
using Otvetmailru.WebAPI.AppConfiguration.ServicesExtensions;
using Otvetmailru.Entities;
using Serilog;

namespace MyProjectOtvetmailru;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddSerilogConfiguration();
        //builder.Services.AddDbContextConfiguration(configuration);
        builder.Services.AddVersioningConfiguration();
        //builder.Services.AddMapperConfiguration();
        builder.Services.AddControllers(); //1
        builder.Services.AddSwaggerConfiguration();
        //builder.Services.AddRepositoryConfiguration();
        //builder.Services.AddBusinessLogicConfiguration();
        var app = builder.Build();

        app.UseSerilogConfiguration(); //use serilog

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerConfiguration(); //use swagger
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseSerilogRequestLogging();

        try
        {
            Log.Information("Application starting...");

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Error("Application finished with error {Error}", ex);
        }
        finally
        {
            Log.Information("Application stopped");
            Log.CloseAndFlush();
        }
    }
}