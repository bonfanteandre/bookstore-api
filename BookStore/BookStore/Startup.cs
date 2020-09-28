using BookStore.Auth.Data;
using BookStore.Auth.Models;
using BookStore.Auth.Security;
using BookStore.Domain.Contracts.Repositories;
using BookStore.Domain.Contracts.Validators;
using BookStore.Domain.Contracts.Workflows;
using BookStore.Domain.Validation.Validators;
using BookStore.Domain.Workflows;
using BookStore.Infrastructure.Context;
using BookStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookStore
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
            services.AddCors();

            services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultconnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<AccessManager>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddJwtSecurity(signingConfigurations, tokenConfigurations);

            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksValidator, BooksValidator>();
            services.AddScoped<IBooksWorklflow, BooksWorkflow>();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            new IdentityInitializer(context, userManager, roleManager).Initialize();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
