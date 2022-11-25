using AutoMapper;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Otvetmailru.Services.Models;
using Otvetmailru.Services.MapperProfile;

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