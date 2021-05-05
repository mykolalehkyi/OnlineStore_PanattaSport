using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStore.Data.DTO_ViewModels
{
    public class CategoriesProductRequestDTO
    {
        [StringLength(255)]
        public string[] MuscleNames { get; set; }
    }
}
