using MediatR;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;