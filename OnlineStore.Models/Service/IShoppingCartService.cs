using OnlineStore.Data.DTO_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Service
{
    public interface IShoppingCartService
    {
        SuccessMessageCounterResponse AddProductToCart(int productId);
        SuccessMessageResponse ClearCart();
        SuccessMessageResponse ConfirmCart();
        List<ShoppingCartDTO> GetShoppingCartDTOs();
    }
}
