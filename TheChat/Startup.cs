using TheChat.Extensions;

namespace TheChat
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger();
            services.AddEndpointsApiExplorer();
            services.AddResponseCompression();
            services.AddControllers();
            services.AddApplicationServices();
            services.AddDbConnection();
            services.AddHttpContextAccessor();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheChat v1"));
                    c.InjectStylesheet("/swagger-ui/custom.css");
                });
            //}
            app.UseResponseCompression();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCustomMiddleware();

            app.UseCors("TheChatCorePolicy");

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
