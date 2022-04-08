using Blogs.Application;
using Blogs.Application.Repositories;
using Blogs.Infrastructure;
using Blogs.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Blogs
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext<BlogsDbContext>( x =>
                x.UseSqlServer( Configuration.GetConnectionString( "BlogsConnection" ) ) );
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddSwaggerGen( c =>
             {
                 c.SwaggerDoc( "v1", new OpenApiInfo { Title = "Blogs", Version = "v1" } );
             } );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Blogs v1" ) );
            }

            app.UseRouting();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllers();
            } );
        }
    }
}
