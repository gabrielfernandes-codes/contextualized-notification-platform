using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace Api.Build.Infrastructure.Builder;

public class ApiApplicationBuilder()
{
    public string ApplicationName { get; private set; } = "API Application";

    public Action<WebApplicationBuilder>? ExtendApplicationBuilder { get; private set; }

    public Action<WebApplication>? ExtendApplication { get; private set; }

    public ApiApplicationBuilder WithApplicationName(string applicationName)
    {
        ApplicationName = applicationName;

        return this;
    }

    public ApiApplicationBuilder WithBuilderExtension(Action<WebApplicationBuilder> extendApplicationBuilder)
    {
        ExtendApplicationBuilder = extendApplicationBuilder;

        return this;
    }

    public ApiApplicationBuilder WithAppExtension(Action<WebApplication> extendApplication)
    {
        ExtendApplication = extendApplication;

        return this;
    }

    public WebApplication Build()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi("public", options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info = new()
                {
                    Title = ApplicationName
                };

                return Task.CompletedTask;
            });
        });

        ExtendApplicationBuilder?.Invoke(builder);

        var app = builder.Build();

        app.MapOpenApi("/openapi/{documentName}.json");

        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference(options =>
              {
                  options.Title = $"{ApplicationName} Docs - {{documentName}}";
                  options.EndpointPathPrefix = "/docs/{documentName}";
              });
        }

        app.UseHttpsRedirection();

        ExtendApplication?.Invoke(app);

        return app;
    }

}