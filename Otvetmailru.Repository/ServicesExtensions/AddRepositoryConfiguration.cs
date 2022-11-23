using Otvetmailru.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Otvetmailru.Entity;

namespace Otvetmailru.Repository;

public class AddRepositoryConfiguration
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