using MyProjectOtvetmailru.AppConfiguration.ApplicationExtensions;
using MyProjectOtvetmailru.AppConfiguration.ServicesExtensions;
using Serilog;

namespace MyProjectOtvetmailru;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddSerilogConfiguration(); //Add serilog
        builder.Services.AddVersioningConfiguration(); //add api versioning
        builder.Services.AddSwaggerConfiguration(); //add swagger configuration
        builder.Services.AddControllers();

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
            Log.Error("Application finished with error {error}", ex);
        }
        finally
        {
            Log.Information("Application stopped");
            Log.CloseAndFlush();
        }
    }
}