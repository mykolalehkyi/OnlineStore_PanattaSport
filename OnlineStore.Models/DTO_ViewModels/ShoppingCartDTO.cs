using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.DTO_ViewModels
{
    public class ShoppingCartDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}
