using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.DTO_ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Service
{
    public interface IMuscleLoadService
    {
        List<AdminMuscleLoadViewDTO> GetAllMuscleLoad();
        void DeactivateMuscleLoad(int id);
        void ActivateMuscleLoad(int id);
        void updateMuscleLoad(AdminMuscleLoadEditDTO adminMuscleLoadEditDTO);
        void createMuscleLoad(AdminMuscleLoadCreateDTO adminMuscleLoadCreateDTO);
    }
}
