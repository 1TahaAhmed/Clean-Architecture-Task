using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using FluentValidation;

namespace ProductCatalog.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product Name.")
            .MaximumLength(100).WithMessage("Don't pass 100 character");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 100");
    }
}