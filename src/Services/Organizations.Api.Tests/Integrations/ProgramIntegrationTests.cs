using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Organizations.Api.Tests.Integrations;

public class ProgramIntegrationTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task SuccessfullyCreateOrganizationV1()
    {
        var response = await _client.PostAsync("/v1/organizations", null);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task SuccessfullyGetOrganizationV1()
    {
        var response = await _client.GetAsync("/v1/organizations/id");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}