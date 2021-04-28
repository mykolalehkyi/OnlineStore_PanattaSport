using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data.Models
{
    public partial class ProductPadding
    {
        [Key]
        public int PaddingId { get; set; }
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(PaddingId))]
        [InverseProperty("ProductPadding")]
        public virtual Padding Padding { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductPadding")]
        public virtual Product Product { get; set; }
    }
}
