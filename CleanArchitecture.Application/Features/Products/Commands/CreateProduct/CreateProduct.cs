using MediatR;

namespace CleanArchitecture.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;