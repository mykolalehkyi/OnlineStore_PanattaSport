using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.DTO_ViewModels
{
    public class ProductViewDTO
    {
        public int ProductId { get; set; }
        [StringLength(255)]
        public string ProductName { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? StandardLoad { get; set; }
        public int? OptionalLoad { get; set; }
    }
}
