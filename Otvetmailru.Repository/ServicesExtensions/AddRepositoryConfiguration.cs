using Microsoft.EntityFrameworkCore;
using Otvetmailru.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Otvetmailru.Repository
{
    public static partial class ServicesExtensions
        {
            public static void AddRepositoryConfiguration(this IServiceCollection services)
            {
                services.AddScoped<DbContext, Context>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            }
        }
    }