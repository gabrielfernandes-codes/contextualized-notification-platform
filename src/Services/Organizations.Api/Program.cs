using Api.Build.Infrastructure.Builder;
using Organizations.Api.Routes;

namespace Organizations.Api;

public class Program
{
    public const string Name = "Organizations.Api";

    public static void Main()
    {
        var server = new ApiApplicationBuilder().WithApplicationName(Name).Build();

        server.MapRouteGroup();

        server.Run();
    }
}