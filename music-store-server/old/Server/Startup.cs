using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Schema;
using MusicStore.Services;

namespace Server
{
    public class Startup
    {
        // https://graphql-dotnet.github.io/docs/getting-started/introduction
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMusicTicketService, MusicTicketService>();
            services.AddSingleton<MusicTicketType>();
            //services.AddSingleton<MusicTicketsQuery>();
            //services.AddSingleton<MusicTicketsSchema>();

            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<OrderStatusesEnum>();
            services.AddSingleton<MusicStoreQuery>();
            services.AddSingleton<MusicStoreSchema>();
            services.AddSingleton<OrderCreateInputType>();
            services.AddSingleton<OrdersMutation>();
            services.AddSingleton<OrdersSubscription>();
            services.AddSingleton<OrderEventType>();
            services.AddSingleton<IOrderEventService, OrderEventService>();
            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = this.Environment.IsDevelopment();
            })
            .AddWebSockets() // Add required services for web socket support
            .AddDataLoader(); // Add required services for DataLoader support

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("fiver",
            //        policy => policy.WithOrigins("http://localhost:21314"));
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<MusicStoreSchema>("/graphql");
            app.UseGraphQL<MusicStoreSchema>("/graphql");
        }
    }
}
