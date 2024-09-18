namespace Organizations.Api.Tests.Integrations;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Xunit;

public class ProgramIntegrationTests(WebApplicationFactory<OrganizationApiProgram> factory) : IClassFixture<WebApplicationFactory<OrganizationApiProgram>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task PostOrganization_Returns201Created()
    {
        var response = await _client.PostAsync("/organizations", null);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}