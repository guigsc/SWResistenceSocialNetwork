using Microsoft.Extensions.DependencyInjection;
using SWResistenceSocialNetwork.Application.Interfaces;
using SWResistenceSocialNetwork.Application.Services;
using SWResistenceSocialNetwork.Domain.Interfaces.Repositories;
using SWResistenceSocialNetwork.Domain.Interfaces.Services;
using SWResistenceSocialNetwork.Domain.Services;
using SWResistenceSocialNetwork.Infrastructure.Repository;

namespace SWResistenceSocialNetwork.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IRebelRepository, RebelRepository>();

            // Application services
            services.AddScoped<IRebelService, RebelService>();
            services.AddScoped<IReportRebelService, ReportRebelService>();
            services.AddScoped<ITradeApplicationService, TradeApplicationService>();
            services.AddScoped<IReportingService, ReportingService>();

            // Domain services
            services.AddScoped<ITradeService, TradeService>();
        }
    }
}
