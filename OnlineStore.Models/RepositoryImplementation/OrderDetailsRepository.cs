using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.RepositoryImplementation
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly StoreSportDbContext context;

        public OrderDetailsRepository(StoreSportDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
