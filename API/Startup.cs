using API.Contexts;
using API.GraphQL.Mutations;
using API.GraphQL.Queries;
using API.GraphQL.Schemas;
using API.Interfaces.Repositories;
using API.Repositories;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
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
            services.AddDbContext<CourseContext>(options => options.UseSqlServer(ConnectionString));

            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<CourseQuery>();
            services.AddScoped<CourseMutation>();
            services.AddScoped<AppSchema>();

#pragma warning disable CS0612 // Type or member is obsolete
            services.AddGraphQL().AddSystemTextJson();
#pragma warning restore CS0612 // Type or member is obsolete

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddCors(policy =>
            {
                policy.AddPolicy("C", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses.GraphQL v1"));

            app.UseCors("C");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseGraphQL<AppSchema>("/graphql");
            app.UseGraphQLGraphiQL("/ui/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
