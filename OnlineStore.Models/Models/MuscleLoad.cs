using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineStore.Data.Models
{
    public partial class MuscleLoad
    {
        public MuscleLoad()
        {
            ProductMuscleLoad = new HashSet<ProductMuscleLoad>();
        }

        [Key]
        public int MuscleLoadId { get; set; }
        [StringLength(255)]
        public string MuscleName { get; set; }
        public bool Disabled { get; set; }

        [InverseProperty("MuscleLoad")]
        public virtual ICollection<ProductMuscleLoad> ProductMuscleLoad { get; set; }
    }
}
