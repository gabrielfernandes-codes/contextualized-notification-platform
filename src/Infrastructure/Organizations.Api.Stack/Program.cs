using ContainerImage.Build.Infrastructure.Builders;
using Pulumi.AzureNative.Resources;

return await Pulumi.Deployment.RunAsync(async () =>
{
    var resourceGroup = new ResourceGroup("resourceGroup");

    var image = new ContainerImageBuilder()
        .WithContext("../../../")
        .WithDockerfile("../../Services/Organizations.Api/Dockerfile")
        .WithImageName("organizations:api")
        .Build();

    return new Dictionary<string, object?>
    {
        ["image"] = image
    };
});