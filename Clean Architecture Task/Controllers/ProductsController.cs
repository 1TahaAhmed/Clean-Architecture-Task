using CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Features.Products.Queries.GetProductById;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(ISender mediator, ILogger<ProductsController> logger)
    {
        _logger = logger;

        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all products at {Time}", DateTime.UtcNow);

        var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        var productId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
    }
}