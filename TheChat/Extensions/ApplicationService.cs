using TheChat.BalLayer.Interfaces;
using TheChat.BalLayer.Services;
using TheChat.Utility.Common;
using static TheChat.DalLayer.Repositories.Repository_TheChatDB;

namespace TheChat.Extensions
{
    public static class ApplicationService
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //AddCors

            services.AddCors(options =>
            {
                options.AddPolicy("TheChatCorePolicy",
                    builder => builder
                    .WithOrigins(AppSettings.WithOrigins) // the Angular app url
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });



            //ActionFilters

            services.AddTransient(typeof(ActionFilters.TokenVerify));

            //Utility

            services.AddTransient(typeof(EmailHelper));

            //Repository 

            services.AddTransient(typeof(Repository_Chat));
            services.AddTransient(typeof(Repository_Authentication));
            services.AddTransient(typeof(Repository_AuthenticationDetails));
            services.AddTransient(typeof(Repository_Conversation));
            services.AddTransient(typeof(Repository_ConversationDetails));


            //Iterface connect with service
            services.AddTransient<IAuthentication, Service_Auth>();
            services.AddTransient<IChatGpt, Service_Chat>();



            services.AddTransient(typeof(Service_Common));



            return services;

        }
    }
}
