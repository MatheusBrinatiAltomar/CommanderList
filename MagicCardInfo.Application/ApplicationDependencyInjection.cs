using MagicCardInfo.Application.Services;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Domain.Services;
using MagicCardInfo.Infrastructure.Models;
using MagicCardInfo.Infrastructure.Persistance;
using MagicCardInfo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagicCardInfo.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                
            services.AddScoped<CardService>();
            services.AddScoped<IScryfallService, ScryfallService>();
            services.AddScoped<ICardRepository, CardRepositry>();

            return services;
        }
    }
}
