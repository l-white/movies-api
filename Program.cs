using movies_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace movies_api {
    public class Program {
        public static void Main (string[] args) {
            // add CORS
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder (args);

            // connection string -- change to dynamic on deployment
            var connectionString = "server=localhost;user=SA;password=MyPass@word;database=";

            builder.Services.AddCors (options => {
                options.AddDefaultPolicy (
                    builder => {
                        builder.WithOrigins ("http://localhost:5228")
                            .AllowAnyHeader ()
                            .AllowAnyMethod ();
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers ();
            builder.Services.AddEndpointsApiExplorer ();

            // add Swagger
            builder.Services.AddSwaggerGen (options => {
                options.SwaggerDoc ("v1", new OpenApiInfo {
                    Version = "v1",
                        Title = "Movies API",
                        Description = "An ASP.NET Core Web API for actors and movies",
                        TermsOfService = new Uri ("https://example.com/terms"),
                        Contact = new OpenApiContact {
                            Name = "Example Contact",
                                Url = new Uri ("https://example.com/contact")
                        },
                        License = new OpenApiLicense {
                            Name = "Example License",
                                Url = new Uri ("https://example.com/license")
                        }
                });
            });
            //builder.Services.AddDbContext<ActorContext>(opt => opt.UseInMemoryDatabase("ActorList"));
            builder.Services.AddDbContext<ActorContext> (
                dbContextOptions => dbContextOptions
                .UseSqlServer (connectionString)
                .EnableSensitiveDataLogging () // <-- These two calls are optional but help
                .EnableDetailedErrors () // <-- with debugging (remove for production).
            );
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
            //});
            var app = builder.Build ();

            // Configure the HTTP request pipeline.

            if (builder.Environment.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
                app.UseSwaggerUI (options => {
                    options.SwaggerEndpoint ("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            // Enable middleware for serving generated JSON and the Swagger UI if in development enviornment
            if (app.Environment.IsDevelopment () || app.Environment.IsProduction ()) {
                app.UseSwagger ();
                app.UseSwaggerUI ();
            }

            app.UseHttpsRedirection ();

            app.UseAuthorization ();

            // add CORS
            app.UseCors ();

            app.MapControllers ();

            app.Run ();
        }
    }
}