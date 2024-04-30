using Catalog.Application.Abstractiions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.CommandHandlers
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public CreateCatalogCommandHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var catalog = new ProductCatalog
                {
                    Name = request.Name,
                    Description = request.Description,
                };

                await _context.Catalogs.AddAsync(catalog, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Name}",
                    isSucces = true
                };
            }

            return new ResponseModel
            {
                Message = "Catalog null",
                StatusCode = 400
            };
        }
    }
}
