using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VGStore.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string DescripcionCorta { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="El valor debe de ser mayor que 0")]
        public double Precio { get; set; }
        public string Imagen { get; set; }
        [Display(Name ="Categoria")]
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Categories Categoria { get; set; }
        [Display(Name = "Consola")]
        public int IdConsole { get; set; }
        [ForeignKey("IdConsole")]
        public virtual Consoles Consoles { get; set; }
    }
}
