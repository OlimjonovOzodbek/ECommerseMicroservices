using Catalog.Application.Abstractiions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.QueryHandlers
{
    public class GetByIdCatalogQueryHandler : IRequestHandler<GetByIdCatalogQuery, ProductCatalog>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;
        public GetByIdCatalogQueryHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ProductCatalog> Handle(GetByIdCatalogQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x => x.Id == request.Id);

            return catalog;
        }
    }
}
