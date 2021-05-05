using OnlineStore.Data.DTO_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Service
{
    public interface IMuscleLoadService
    {
        List<MuscleLoadViewDTO> GetAllMuscleLoad();
    }
}
