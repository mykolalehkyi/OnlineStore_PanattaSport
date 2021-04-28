using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.RepositoryImplementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly StoreSportDbContext context;

        public ProductRepository(StoreSportDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
