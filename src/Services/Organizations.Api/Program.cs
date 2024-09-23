using Api.Infrastructure.Server.Builder;
using Organizations.Api.Routes;

namespace Organizations.Api;

public class Program
{
    public static void Main()
    {
        var server = new ApiApplicationBuilder().Build();

        server.MapRouteGroup();

        server.Run();
    }
}