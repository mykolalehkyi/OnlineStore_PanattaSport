using AutoMapper;
using OnlineStore.Data.DTO_ViewModels;
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

        public List<MuscleLoadViewDTO> GetAllMuscleLoad()
        {
            List<MuscleLoad> listMuscleLoad = unitOfWork.MuscleLoad.GetAll().ToList();
            return mapper.Map<List<MuscleLoad>, List<MuscleLoadViewDTO>>(listMuscleLoad);
        }
    }
}
