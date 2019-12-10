using GQL.AppService.Data;
using GQL.AppService.Domain.Commands;
using GQL.AppService.Domain.Queries;
using GQL.AppService.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GQL.AppService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(opts => 
            {
                var cs = Configuration.GetConnectionString("GQLAppDb");
                opts.UseSqlServer(cs);
            });

            services.AddTransient<IQueryFactory, QueryFactory>();
            services.AddTransient<ICommandFactory, CommandFactory>();
            services.AddTransient<IWeightService, WeightService>();
            services.AddTransient<ICalorieService, CalorieService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
