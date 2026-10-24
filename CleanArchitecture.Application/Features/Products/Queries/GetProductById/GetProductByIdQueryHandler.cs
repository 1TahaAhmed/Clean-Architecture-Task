using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Common.Interfaces;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IApplicationDbContext _context;

    public GetProductByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null) return null;

        return new ProductDto(product.Id, product.Name, product.Price);
    }
}