
using CoreAPI_Filters.Filters;
using CoreAPI_Filters.Repo;
using Microsoft.Extensions.Options;

namespace CoreAPI_Filters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();


            builder.Services.AddControllers(options => 
            { 
                options.Filters.Add<GlobalExceptionFilter>();
                options.Filters.Add<CustomActionFilter>(); });
            var app = builder.Build();
          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                c.RoutePrefix = string.Empty; // 👈 KEY LINE
            });
            app.MapControllers();

            app.Run();
        }
    }
}
