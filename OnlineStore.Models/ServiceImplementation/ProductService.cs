using AutoMapper;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using OnlineStore.Data.Service;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Data.ServiceImplementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<ProductViewDTO> GetAllProducts()
        {
            List<Product> listProduct = unitOfWork.Product.GetAll().ToList();
            return mapper.Map<List<Product>, List<ProductViewDTO>>(listProduct);
        }
    }
}
