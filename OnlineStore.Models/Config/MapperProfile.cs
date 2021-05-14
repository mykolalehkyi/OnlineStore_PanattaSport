using AutoMapper;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.Models;

namespace OnlineStore.Data.HelpTools
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewDTO>();
            CreateMap<ProductViewDTO, Product>();
            CreateMap<Product, AdminProductViewDTO>();
            CreateMap<AdminProductViewDTO, Product>();
            CreateMap<MuscleLoad, MuscleLoadViewDTO>();
            CreateMap<MuscleLoadViewDTO, MuscleLoad>();
        }
    }
}
