using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics.CodeAnalysis;

namespace Api.Build.Infrastructure.Builder;

public static class ApiRouteGroupBuilder
{
    public static RouteGroupBuilder MapApiGroup(
        this IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string prefix,
        string name
        )
    {
        var group = endpoints.MapGroup(prefix).WithOpenApi().WithTags(name);

        return group;
    }
}