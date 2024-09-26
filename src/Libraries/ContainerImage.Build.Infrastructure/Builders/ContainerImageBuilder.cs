using Pulumi.DockerBuild;
using Pulumi.DockerBuild.Inputs;

namespace ContainerImage.Build.Infrastructure.Builders;

public class ContainerImageBuilder
{
    private string? _context;
    private string? _dockerfile;
    private string? _imageName;

    public ContainerImageBuilder WithContext(string context)
    {
        _context = context;

        return this;
    }

    public ContainerImageBuilder WithDockerfile(string dockerfile)
    {
        _dockerfile = dockerfile;

        return this;
    }

    public ContainerImageBuilder WithImageName(string imageName)
    {
        _imageName = imageName;

        return this;
    }

    public Image Build()
    {
        if (_context == null || _dockerfile == null || _imageName == null)
        {
            throw new InvalidOperationException("Context, Dockerfile, and ImageName must be provided.");
        }

        var image = new Image(_imageName, new ImageArgs
        {
            Context = new BuildContextArgs
            {
                Location = _context,
            },
            Dockerfile = new DockerfileArgs
            {
                Location = _dockerfile,
            },
            Push = false,
        });

        return image;
    }
}