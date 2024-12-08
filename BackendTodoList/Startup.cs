using BackendTodoList.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoListApp.Services;

namespace BackendTodoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure PostgreSQL database context
            services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DBConnection")));

            // Add support for controllers
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MappingModel));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });            
            services.AddControllers();

            // Register Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "To-Do List API",
                    Description = "A simple API to manage tasks"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Add middleware for exception handling
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Enable Swagger and Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "To-Do List API v1");
                c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root
            });

            app.UseRouting();
            app.UseCors("AllowAll");
            // Configure controller endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Maps controllers to endpoints
            });

        }
    }
}
