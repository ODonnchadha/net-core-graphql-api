using Courses.GraphQL.Contexts;
using Courses.GraphQL.Repositories;
using Courses.GraphQL.GraphQL.Queries;
using Courses.GraphQL.GraphQL.Schemas;
using Courses.GraphQL.Interfaces.Repositories;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Courses.GraphQL.GraphQL.Mutations;

namespace Courses.GraphQL
{
    public class Startup
    {

        public string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<CourseQuery>();
            services.AddScoped<CourseMutation>();
            services.AddScoped<AppSchema>();

#pragma warning disable CS0612 // Type or member is obsolete
            services.AddGraphQL().AddSystemTextJson();
#pragma warning restore CS0612 // Type or member is obsolete

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Courses.GraphQL", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses.GraphQL v1"));

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseGraphQL<AppSchema>();
            app.UseGraphQLGraphiQL("/ui/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
