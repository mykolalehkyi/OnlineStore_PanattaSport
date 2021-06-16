using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.Data.DTO_ViewModels.Admin
{
    public class AdminMuscleLoadEditDTO
    {
        [Key]
        public int MuscleLoadId { get; set; }
        [StringLength(255)]
        public string MuscleName { get; set; }
    }
}
