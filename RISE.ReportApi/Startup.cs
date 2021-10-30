using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RISE.BusinessLayer.Abstract;
using RISE.BusinessLayer.Concrete;
using RISE.ReportApi.Consumers;
using RISE.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RISE.ReportApi
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
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ReportDetailCreatedConsumer>();
                x.AddConsumer<ReportDetailNotCreatedConsumer>();

                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(Configuration.GetConnectionString("RabbitMQ"));

                    config.ReceiveEndpoint(RabbitMQSettingsModel.ReportDetailCreatedQueueName, y =>
                    {
                        y.ConfigureConsumer<ReportDetailCreatedConsumer>(context);                        
                    });

                    config.ReceiveEndpoint(RabbitMQSettingsModel.ReportDetailNotCreatedQueueName, y =>
                    {
                        y.ConfigureConsumer<ReportDetailNotCreatedConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddSingleton(typeof(IReportBl), typeof(ReportBl));

            services.AddCors();

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
                x.JsonSerializerOptions.DefaultBufferSize = 4 * 1024;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
