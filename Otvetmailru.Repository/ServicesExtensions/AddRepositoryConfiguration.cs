using Microsoft.EntityFrameworkCore;
using Otvetmailru.Entity;

namespace Otvetmailru.Repository
{
    public static partial class ServicesExtensions
        {
            public static void AddRepositoryConfiguration(IServiceCollection services)
            {
                services.AddScoped<DbContext, Context>();
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            }
        }
    }