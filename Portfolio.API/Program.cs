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

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}