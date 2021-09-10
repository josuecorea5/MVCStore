using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VGStore.Models
{
    public class Categories
    {
        [Key]
        public int IdCategory { get; set; }
        [Required]
        [DisplayName("Nombre de Categoría")]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="El valor debe ser mayor que 0")]
        public int Order { get; set; } 
    }
}
