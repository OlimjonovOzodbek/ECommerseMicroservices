using Catalog.Application.Abstractiions;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.QueryHandlers
{
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, List<ProductCatalog>>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;
        public GetAllCatalogsQueryHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<List<ProductCatalog>> IRequestHandler<GetAllCatalogsQuery, List<ProductCatalog>>.Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogs = await _context.Catalogs.ToListAsync();

            return catalogs;
        }
    }
}
