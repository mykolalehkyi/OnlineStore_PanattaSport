using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Product> GetAllActiveProducts()
        {
            return context.Product.Where(x => x.Disabled == false);
        }

        public IEnumerable<Product> GetActiveProductsWithMuscleLoad(List<int> muscleLoadIds)
        {
            return context.Product
                .Include(x => x.ProductMuscleLoad)
                    .ThenInclude(y => y.MuscleLoad)
                .Where(x => (x.Disabled == false) && 
                            (x.ProductMuscleLoad.Any(y => muscleLoadIds.Contains(y.MuscleLoad.MuscleLoadId)))
                       );
        }

        public IQueryable<Product> GetProductByIdWithMuscleLoad(int id)
        {
            return context.Product
                .Include(x => x.ProductMuscleLoad)
                    .ThenInclude(y => y.MuscleLoad)
                .Where(x => x.ProductId == id);
        }
    }
}
