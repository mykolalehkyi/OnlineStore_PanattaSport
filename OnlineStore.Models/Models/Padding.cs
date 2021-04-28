using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data.Models
{
    public partial class Padding
    {
        public Padding()
        {
            ProductPadding = new HashSet<ProductPadding>();
        }

        [Key]
        public int PaddingId { get; set; }
        [StringLength(255)]
        public string PaddingName { get; set; }

        [InverseProperty("Padding")]
        public virtual ICollection<ProductPadding> ProductPadding { get; set; }
    }
}
