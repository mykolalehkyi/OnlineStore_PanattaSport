using AutoMapper;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.DTO_ViewModels.Admin;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.HelpTools
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewDTO>();
            CreateMap<ProductViewDTO, Product>();
            CreateMap<Product, ProductDetailsDTO>();
            CreateMap<ProductDetailsDTO, Product>();
            CreateMap<Product, AdminProductViewDTO>();
            CreateMap<AdminProductViewDTO, Product>();
            CreateMap<MuscleLoad, AdminMuscleLoadViewDTO>();
            CreateMap<AdminMuscleLoadViewDTO, MuscleLoad>();
            CreateMap<AdminMuscleLoadEditDTO, MuscleLoad>();
            CreateMap<MuscleLoad, AdminMuscleLoadEditDTO>();
            CreateMap<AdminMuscleLoadCreateDTO, MuscleLoad>();
            CreateMap<MuscleLoad, AdminMuscleLoadCreateDTO>();
        }
    }
}
