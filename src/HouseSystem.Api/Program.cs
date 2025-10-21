namespace HouseSystem.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || true)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection(); // Enable HTTPS locally
        }

        // Disable HTTPS redirection on Render (Production)
        if (!app.Environment.IsDevelopment())
        {
            // Do NOT use app.UseHttpsRedirection() on Render
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
