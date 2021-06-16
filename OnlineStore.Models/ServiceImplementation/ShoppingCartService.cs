using AutoMapper;
using Microsoft.AspNetCore.Http;
using OnlineStore.Data.Config;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.Identity;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using OnlineStore.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OnlineStore.Data.ServiceImplementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public SuccessMessageCounterResponse AddProductToCart(int productId)
        {
            Product product = unitOfWork.Product.Get(productId);
            List<ShoppingCartDTO> listShoppingCartDTOs = new List<ShoppingCartDTO>();

            if(httpContextAccessor.HttpContext.Session.GetInt32(SessionConstants.CARTCOUNTER) != null)
            {
                listShoppingCartDTOs = httpContextAccessor.HttpContext.Session.GetObject<List<ShoppingCartDTO>>(SessionConstants.CARTITEMS);
            }

            if(listShoppingCartDTOs.Any(x=> x.ProductId == product.ProductId)) //product already in list
            {
                ShoppingCartDTO shoppingCartDTO = listShoppingCartDTOs.Single(x=> x.ProductId == product.ProductId);
                shoppingCartDTO.Quantity += 1;
                shoppingCartDTO.Total = shoppingCartDTO.UnitPrice * shoppingCartDTO.Quantity; 
            }
            else //product is not in the list
            {
                ShoppingCartDTO shoppingCartDTO = new ShoppingCartDTO();
                shoppingCartDTO.ProductId = product.ProductId;
                shoppingCartDTO.ProductName = product.ProductName;
                shoppingCartDTO.Quantity = 1;
                shoppingCartDTO.UnitPrice = product.Price;
                shoppingCartDTO.Total = product.Price;
                listShoppingCartDTOs.Add(shoppingCartDTO);
            }
            
            httpContextAccessor.HttpContext.Session.SetInt32(SessionConstants.CARTCOUNTER,listShoppingCartDTOs.Count) ;
            httpContextAccessor.HttpContext.Session.SetObject(SessionConstants.CARTITEMS, listShoppingCartDTOs);

            return new SuccessMessageCounterResponse()
            {
                Success = true,
                Counter = listShoppingCartDTOs.Count,
                Message = "Successfully added item into cart"
            };
        }

        public List<ShoppingCartDTO> GetShoppingCartDTOs()
        {
            if (httpContextAccessor.HttpContext.Session.GetInt32(SessionConstants.CARTCOUNTER) != null)
            {
                return httpContextAccessor.HttpContext.Session.GetObject<List<ShoppingCartDTO>>(SessionConstants.CARTITEMS);
            }
            else
            {
                return new List<ShoppingCartDTO>();
            }
        }

        public SuccessMessageResponse ConfirmCart()
        {
            if (httpContextAccessor.HttpContext.Session.GetInt32(SessionConstants.CARTCOUNTER) == null)
            {
                return new SuccessMessageResponse()
                {
                    Success = false,
                    Message = "Cart is empty."
                };
            }
            List<ShoppingCartDTO> listShoppingCartDTOs = httpContextAccessor.HttpContext.Session.GetObject<List<ShoppingCartDTO>>(SessionConstants.CARTITEMS);
            Orders order = new Orders()
            {
                OrderDate = DateTime.Now,
                OrderNumber = String.Format("{0:ddmmyyyyHHmmss}", DateTime.Now),
                ApplicationUserId = httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>()
            };
            unitOfWork.Orders.Add(order);
            unitOfWork.Complete();
            List<OrderDetails> listOrderDetails = new List<OrderDetails>();
            foreach(var shoppingCart in listShoppingCartDTOs)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrdersOrderId = order.OrderId;
                orderDetails.ProductId = shoppingCart.ProductId;
                orderDetails.Quantity = shoppingCart.Quantity;
                orderDetails.Total = shoppingCart.Total;
                orderDetails.UnitPrice = shoppingCart.UnitPrice;
                listOrderDetails.Add(orderDetails);
            }
            
            unitOfWork.OrderDetails.AddRange(listOrderDetails);
            unitOfWork.Complete();
            httpContextAccessor.HttpContext.Session.Remove(SessionConstants.CARTCOUNTER);
            httpContextAccessor.HttpContext.Session.Remove(SessionConstants.CARTITEMS);
            return new SuccessMessageResponse()
            {
                Success = true,
                Message = "Order successfuly saved."
            };
        }

        public SuccessMessageResponse ClearCart()
        {
            httpContextAccessor.HttpContext.Session.Remove(SessionConstants.CARTCOUNTER);
            httpContextAccessor.HttpContext.Session.Remove(SessionConstants.CARTITEMS);
            return new SuccessMessageResponse()
            {
                Success = true,
                Message = "Cart cleared."
            };
        }

    }
}
