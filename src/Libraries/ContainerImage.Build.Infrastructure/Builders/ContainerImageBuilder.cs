using ContainerImage.Build.Infrastructure.Validators;
using Exceptions.Common;
using FluentValidation;
using FluentValidation.Results;
using Pulumi.DockerBuild;
using Pulumi.DockerBuild.Inputs;

namespace ContainerImage.Build.Infrastructure.Builders;

public class ContainerImageBuilder
{
    public string? Context { get; private set; }

    public string? Dockerfile { get; private set; }

    public string? ImageName { get; private set; }

    public ContainerImageBuilder WithContext(string context)
    {
        Context = context;

        return this;
    }

    public ContainerImageBuilder WithDockerfile(string dockerfile)
    {
        Dockerfile = dockerfile;

        return this;
    }

    public ContainerImageBuilder WithImageName(string imageName)
    {
        ImageName = imageName;

        return this;
    }

    public Image Build()
    {
        var validator = new ContainerImageBuilderValidator();

        ValidationResult result = validator.Validate(this);

        if (!result.IsValid)
        {
            throw new FluentValidationException(result.Errors);
        }

        var image = new Image(ImageName, new ImageArgs
        {
            Context = new BuildContextArgs
            {
                Location = Context,
            },
            Dockerfile = new DockerfileArgs
            {
                Location = Dockerfile,
            },
            Push = false,
        });

        return image;
    }
}