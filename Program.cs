using Microsoft.EntityFrameworkCore;
using movies_api.Models;

namespace movies_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // add CORS
            //var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5228")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ActorContext>(opt => opt.UseInMemoryDatabase("ActorList"));
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
            //});
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // add CORS
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}