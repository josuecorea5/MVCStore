using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGStore.Models.ViewModels
{
    public class ProductosVM
    {
        public Productos Productos { get; set; }
        public IEnumerable<SelectListItem> CategoriasSelectList { get; set; }
        public IEnumerable<SelectListItem> ConsolasSelectList { get; set; }
    }
}
