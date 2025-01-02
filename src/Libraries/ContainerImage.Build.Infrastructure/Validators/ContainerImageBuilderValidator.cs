using ContainerImage.Build.Infrastructure.Builders;
using FluentValidation;

namespace ContainerImage.Build.Infrastructure.Validators;

public class ContainerImageBuilderValidator : AbstractValidator<ContainerImageBuilder>
{
    public ContainerImageBuilderValidator()
    {
        RuleFor(builder => builder.Context).NotEmpty().WithMessage("Context is required.");
        RuleFor(builder => builder.Dockerfile).NotEmpty().WithMessage("Dockerfile is required.");
        RuleFor(builder => builder.ImageName).NotEmpty().WithMessage("ImageName is required.");
    }
}