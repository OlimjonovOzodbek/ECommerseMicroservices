using Catalog.Application.Abstractiions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.CatalogControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public CatalogsController(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCatalog>>> GetAllCatalogs()
        {
            var result = await _mediator.Send(new GetAllCatalogsQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ProductCatalog>> GetByIdCatalog(GetByIdCatalogQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductCatalog>> UpdateCatalog(UpdateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCatalog(DeleteCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
