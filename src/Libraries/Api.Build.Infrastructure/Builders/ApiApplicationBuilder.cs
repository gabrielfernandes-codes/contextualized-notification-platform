using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Build.Infrastructure.Builder;

public class ApiApplicationBuilder
{
    private Action<WebApplicationBuilder>? _extendApplicationBuilder;
    private Action<WebApplication>? _extendApplication;

    public ApiApplicationBuilder ExtendBuilder(Action<WebApplicationBuilder> extendApplicationBuilder)
    {
        _extendApplicationBuilder = extendApplicationBuilder;

        return this;
    }

    public ApiApplicationBuilder ExtendApp(Action<WebApplication> extendApplication)
    {
        _extendApplication = extendApplication;

        return this;
    }

    public WebApplication Build()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        _extendApplicationBuilder?.Invoke(builder);

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

        _extendApplication?.Invoke(app);

        return app;
    }
}