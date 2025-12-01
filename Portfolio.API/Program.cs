using Portfolio.Services.Blog;
using Portfolio.Services.Project;
using Portfolio.Services.Resume;
using Portfolio.Services.Tag;

namespace Portfolio.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        // Register Services
        builder.Services.AddScoped<IBlogService, MockBlogService>();
        builder.Services.AddScoped<IProjectService, MockProjectService>();
        builder.Services.AddScoped<ITagService, MockTagService>();
        builder.Services.AddScoped<IResumeService, MockResumeService>();
        
        // CORS
        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("BlazorWasmPolicy", policy =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    // Allow any origin in development
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
                else
                {
                    // Allow specific origins in production
                    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() 
                                         ?? Array.Empty<string>();
            
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        
        // Enable CORS - must be before UseAuthorization
        app.UseCors("BlazorWasmPolicy");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}