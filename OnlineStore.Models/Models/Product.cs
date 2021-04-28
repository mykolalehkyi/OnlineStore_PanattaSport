using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductFrame = new HashSet<ProductFrame>();
            ProductMuscleLoad = new HashSet<ProductMuscleLoad>();
            ProductPadding = new HashSet<ProductPadding>();
            ProductTexture = new HashSet<ProductTexture>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(255)]
        public string ProductName { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? StandardLoad { get; set; }
        public int? OptionalLoad { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductFrame> ProductFrame { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductMuscleLoad> ProductMuscleLoad { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductPadding> ProductPadding { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductTexture> ProductTexture { get; set; }
    }
}
