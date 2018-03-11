using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Session07.Exam.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Session07.Exam
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var Builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile($"appsettings.{env.EnvironmentName}.json");
            Configuration = Builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IEnumerable<IConfigurationSection> configurationSection = Configuration.GetSection("MemoryCache").GetChildren();
            var connection = @"Server =.; Initial Catalog = Employee; Integrated Security=true";
            services.AddDbContext<PersonContext>(options => options.UseSqlServer(connection));

            var CacheEnably = configurationSection.Where(c => c.Key == "Enabled").ToList().FirstOrDefault().Value;
            services.AddSingleton<IPersonRepository>(provider =>
            {
                var PersonContext = new PersonContext(new DbContextOptions<PersonContext>());
                if (CacheEnably == "1")
                {
                    var MemmoryCache = new MemoryCache(new MemoryCacheOptions());
                    return new PersonRepositoryCacheProxy(PersonContext, MemmoryCache);
                }
                else
                {
                    return new PersonRepository(PersonContext);
                }
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });
         
        }
    }
}
