using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Infrastructure.Server.Builder;

public class ApiApplicationBuilder
{
    private readonly Action<WebApplicationBuilder>? _configureBuilder;
    private readonly Action<WebApplication>? _configureApp;

    public ApiApplicationBuilder(
        Action<WebApplicationBuilder>? configureBuilder = null,
        Action<WebApplication>? configureApp = null)
    {
        _configureBuilder = configureBuilder;
        _configureApp = configureApp;
    }

    public WebApplication Build()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        _configureBuilder?.Invoke(builder);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            if (app.Environment.IsDevelopment())
            {
                options.EnableTryItOutByDefault();
                options.EnablePersistAuthorization();
            }
        });

        app.UseHttpsRedirection();

        app.MapControllers();

        _configureApp?.Invoke(app);

        return app;
    }
}