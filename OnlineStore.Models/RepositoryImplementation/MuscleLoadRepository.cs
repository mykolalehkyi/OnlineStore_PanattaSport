using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.RepositoryImplementation
{
    public class MuscleLoadRepository : Repository<MuscleLoad>, IMuscleLoadRepository
    {
        private readonly StoreSportDbContext context;

        public MuscleLoadRepository(StoreSportDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<MuscleLoad> GetAllActiveMuscleLoad()
        {
            return context.MuscleLoad.Where(x => x.Disabled == false);
        }
    }
}
