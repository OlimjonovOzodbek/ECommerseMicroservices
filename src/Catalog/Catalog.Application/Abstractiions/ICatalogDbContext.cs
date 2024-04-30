using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Abstractiions
{
    public interface ICatalogDbContext
    {
        public DbSet<ProductCatalog> Catalogs { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
