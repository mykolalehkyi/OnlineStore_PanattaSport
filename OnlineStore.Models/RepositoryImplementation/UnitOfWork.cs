using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreSportDbContext context;

        public IProductRepository Product { get; private set; }

        public UnitOfWork(StoreSportDbContext context)
        {
            this.context = context;
            Product = new ProductRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
