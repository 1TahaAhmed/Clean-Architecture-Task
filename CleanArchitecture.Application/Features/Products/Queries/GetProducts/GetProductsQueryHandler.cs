using CleanArchitecture.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Common.Interfaces;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AsNoTracking()
            .Select(p => new ProductDto(p.Id, p.Name, p.Price))
            .ToListAsync(cancellationToken);
    }
}