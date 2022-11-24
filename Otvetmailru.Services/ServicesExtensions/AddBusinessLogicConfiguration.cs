using AutoMapper;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
    }
}