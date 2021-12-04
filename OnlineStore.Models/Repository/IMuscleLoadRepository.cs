using OnlineStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.Data.Repository
{
    public interface IMuscleLoadRepository : IRepository<MuscleLoad>
    {
        IQueryable<MuscleLoad> GetAllActiveMuscleLoad();
    }
}
