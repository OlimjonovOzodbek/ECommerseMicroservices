using Catalog.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Commands
{
    public class UpdateCatalogCommand : ProductCatalogDTO, IRequest<ProductCatalog>
    {
        public Guid Id { get; set; }
    }
}
