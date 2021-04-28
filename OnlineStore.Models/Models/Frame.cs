using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data.Models
{
    public partial class Frame
    {
        public Frame()
        {
            ProductFrame = new HashSet<ProductFrame>();
        }

        [Key]
        public int FrameId { get; set; }
        public int? FrameName { get; set; }

        [InverseProperty("Frame")]
        public virtual ICollection<ProductFrame> ProductFrame { get; set; }
    }
}
