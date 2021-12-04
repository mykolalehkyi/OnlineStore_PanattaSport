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

        public ProductDetailsDTO GetProductDetailsById(int id)
        {
            Product product = unitOfWork.Product.GetProductByIdWithMuscleLoad(id).First();
            ProductDetailsDTO productDetailsDTO = mapper.Map<Product, ProductDetailsDTO>(product);
            productDetailsDTO.MuscleLoadNames = product.ProductMuscleLoad.Select(x => x.MuscleLoad.MuscleName).ToList();
            return productDetailsDTO;
        }

        public List<AdminProductViewDTO> GetAllProducts()
        {
            List<Product> listProduct = unitOfWork.Product.GetAll().ToList();
            return mapper.Map<List<Product>, List<AdminProductViewDTO>>(listProduct);
        }

        public List<ProductViewDTO> GetAllActiveProducts()
        {
            List<Product> listProduct = unitOfWork.Product.GetAllActiveProducts().ToList();
            return mapper.Map<List<Product>, List<ProductViewDTO>>(listProduct);
        }

        public List<ProductViewDTO> GetActiveProductCategorized(List<int> muscleLoadIds)
        {
            List<Product> listProductCategorized;
            if (muscleLoadIds.Count > 0)
            {
                listProductCategorized = unitOfWork.Product.GetActiveProductsWithMuscleLoad(muscleLoadIds).ToList();

            }
            else
            {
                listProductCategorized = unitOfWork.Product.GetAllActiveProducts().ToList();
            }
            return mapper.Map<List<Product>, List<ProductViewDTO>>(listProductCategorized);
        }

        public void DeactivateProduct(int id)
        {
            var product = unitOfWork.Product.Find(id);
            product.Disabled = true;
            unitOfWork.Product.Update(product);
            unitOfWork.Complete();
        }

        public void ActivateProduct(int id)
        {
            var product = unitOfWork.Product.Find(id);
            product.Disabled = false;
            unitOfWork.Product.Update(product);
            unitOfWork.Complete();
        }
    }
}
