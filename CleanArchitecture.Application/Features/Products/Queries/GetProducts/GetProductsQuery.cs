using MediatR;
using ProductCatalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.Products.Queries.GetProducts
{
    public record class GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
}
