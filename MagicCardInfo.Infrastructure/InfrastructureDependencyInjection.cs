using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Domain.Services;
using MagicCardInfo.Infrastructure.Models;
using MagicCardInfo.Infrastructure.Persistance;
using MagicCardInfo.Infrastructure.Services;

namespace MagicCardInfo.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICardRepository, CardRepositry>();
            services.AddScoped<IScryfallService, ScryfallService>();

            return services;
        }
    }
}
