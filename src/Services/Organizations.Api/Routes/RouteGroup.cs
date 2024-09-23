using Api.Infrastructure.Server.Builder;
using Organizations.Api.Routes.Handlers;

namespace Organizations.Api.Routes;

public static class OrganizationRouteGroup
{
    public static WebApplication MapRouteGroup(this WebApplication app)
    {
        var group = app.MapApiGroup("v1/organizations", "Organizations");

        group.MapPost("/", CreateOrganizationEndpoint.Handle).WithDescription("Create a new organization");

        group.MapGet("/{id}", GetOrganizationEndpoint.Handle).WithDescription("Retrieve an organization");

        return app;
    }
}