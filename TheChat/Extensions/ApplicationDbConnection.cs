using Microsoft.EntityFrameworkCore;
using TheChat.DalLayer.DbContexts;
using TheChat.Utility.Common;

namespace TheChat.Extensions
{
    public static class ApplicationDbConnection
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services)
        {
            services.AddDbContextPool<TheChatDB>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseMySQL(AppSettings.MySQLConnectionString);
                optionsBuilder.UseApplicationServiceProvider(serviceProvider);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;

        }
    }
}
