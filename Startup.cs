using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Teste_API_Vehicles.Data;
using Teste_API_Vehicles.Data.Configuration;
using Microsoft.Extensions.Options;
using Teste_API_Vehicles.Data.Repositories;
using Teste_API_Vehicles.Business.Service.IVehicleService;
using API_Vehicles.Business.Service;

namespace Teste_API_Vehicles
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
            services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));
            services.AddSingleton<IDatabaseConfig>(s => s.GetRequiredService<IOptions<DatabaseConfig>>().Value);
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IVehicleService, VehicleService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste_API_Vehicles", Version = "v1" });
            });

            services.AddDbContext<Teste_API_VehiclesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Teste_API_VehiclesContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste_API_Vehicles v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
