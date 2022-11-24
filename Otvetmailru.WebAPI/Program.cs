using Otvetmailru.WebAPI.AppConfiguration.ApplicationExtensions;
using Otvetmailru.WebAPI.AppConfiguration.ServicesExtensions;
using Otvetmailru.Repository;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
//builder.Services.AddMapperConfiguration();
builder.Services.AddControllers(); //1
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositoryConfiguration();
//builder.Services.AddBusinessLogicConfiguration();


var app = builder.Build();

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); //2

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
