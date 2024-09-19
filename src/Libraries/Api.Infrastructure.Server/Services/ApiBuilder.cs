using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Infrastructure.Server.Services;

public class ApiBuilder
{
    private readonly string[] _args;
    private readonly Action<WebApplicationBuilder>? _configureBuilder;
    private readonly Action<WebApplication>? _configureApp;

    public ApiBuilder(
        string[] args,
        Action<WebApplicationBuilder>? configureBuilder = null,
        Action<WebApplication>? configureApp = null)
    {
        _args = args;
        _configureBuilder = configureBuilder;
        _configureApp = configureApp;
    }

    public WebApplication Build()
    {
        var builder = WebApplication.CreateBuilder(_args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        _configureBuilder?.Invoke(builder);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        _configureApp?.Invoke(app);

        return app;
    }
}