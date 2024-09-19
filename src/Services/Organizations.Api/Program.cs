using Api.Infrastructure.Server.Services;

namespace Organizations.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var server = new ApiBuilder(args).Build();

        server.Run();
    }
}