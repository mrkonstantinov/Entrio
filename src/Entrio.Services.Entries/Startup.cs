using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrio.Common.Commands;
using Entrio.Common.Mongo;
using Entrio.Common.RabbitMq;
using Entrio.Services.Activities.Handlers;
using Entrio.Services.Activities.Repositories;
using Entrio.Services.Activities.Services;
using Entrio.Services.Entries.Domain.Repositories;
using Entrio.Services.Entries.Repositories;
using Entrio.Services.Entries.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Entrio.Services.Entries
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddMongoDB(Configuration);
            services.AddScoped<IIndicatorRepository, IndicatorRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateEntry>, CreateEnytryHandler>();
            services.AddScoped<IEntryService, EntryService>();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
