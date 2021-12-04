using AutoMapper;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.DTO_ViewModels.Admin;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using OnlineStore.Data.Service;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Data.ServiceImplementation
{
    public class MuscleLoadService : IMuscleLoadService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MuscleLoadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<AdminMuscleLoadViewDTO> GetAllMuscleLoad()
        {
            List<MuscleLoad> listMuscleLoad = unitOfWork.MuscleLoad.GetAll().ToList();
            return mapper.Map<List<MuscleLoad>, List<AdminMuscleLoadViewDTO>>(listMuscleLoad);
        }

        public void ActivateMuscleLoad(int id)
        {
            MuscleLoad muscleLoad = unitOfWork.MuscleLoad.Get(id);
            muscleLoad.Disabled = false;
            unitOfWork.MuscleLoad.Update(muscleLoad);
            unitOfWork.Complete();
        }

        public void DeactivateMuscleLoad(int id)
        {
            MuscleLoad muscleLoad = unitOfWork.MuscleLoad.Get(id);
            muscleLoad.Disabled = true;
            unitOfWork.MuscleLoad.Update(muscleLoad);
            unitOfWork.Complete();
        }

        public void updateMuscleLoad(AdminMuscleLoadEditDTO adminMuscleLoadEditDTO)
        {
            MuscleLoad muscleLoad = unitOfWork.MuscleLoad.Get(adminMuscleLoadEditDTO.MuscleLoadId);
            mapper.Map(adminMuscleLoadEditDTO, muscleLoad);
            unitOfWork.MuscleLoad.Update(muscleLoad);
            unitOfWork.Complete();
        }

        public void createMuscleLoad(AdminMuscleLoadCreateDTO adminMuscleLoadCreateDTO)
        {
            MuscleLoad muscleLoad = mapper.Map<MuscleLoad>(adminMuscleLoadCreateDTO);
            unitOfWork.MuscleLoad.Add(muscleLoad);
            unitOfWork.Complete();
        }

        public List<AdminMuscleLoadViewDTO> GetAllActiveMuscleLoad()
        {
            List<MuscleLoad> listMuscleLoad = unitOfWork.MuscleLoad.GetAllActiveMuscleLoad().ToList();
            return mapper.Map<List<MuscleLoad>, List<AdminMuscleLoadViewDTO>>(listMuscleLoad);
        }
    }
}
