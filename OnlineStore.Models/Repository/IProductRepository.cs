using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetActiveProductsWithMuscleLoad(List<int> muscleIds);
        IEnumerable<Product> GetAllActiveProducts();
    }
}
