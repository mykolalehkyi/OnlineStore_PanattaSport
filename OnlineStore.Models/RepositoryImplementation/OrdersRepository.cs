using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.RepositoryImplementation
{
    public class OrdersRepository : Repository<Orders>, IOrdersRepository
    {
        private readonly StoreSportDbContext context;

        public OrdersRepository(StoreSportDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
