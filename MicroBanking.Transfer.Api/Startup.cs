using MediatR;
using MicroBanking.Domain.Core.Bus;
using MicroBanking.Infrastructure.IoC;
using MicroBanking.Transfer.Data.Context;
using MicroBanking.Transfer.Domain.EventHandlers;
using MicroBanking.Transfer.Domain.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace MicroBanking.Transfer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc(
              "v1",
              new OpenApiInfo
              {
                  Title = "Transfer",
                  Version = "v1"
              }));

            services.AddMediatR(typeof(Startup));

            services.AddDbContext<TransferDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Transfer"));
            });

            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AddEventBusSubscriptions(app);
        }

        private void AddEventBusSubscriptions(IApplicationBuilder app)
        {
            app.ApplicationServices.GetRequiredService<IEventBus>().Subscribe<TransferCreatedEvent, TransferEventHandler>();
        }
    }
}
