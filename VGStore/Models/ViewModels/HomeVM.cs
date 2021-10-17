using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VGStore.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Productos> Productos { get; set; }
        public IEnumerable<Consoles> Consolas { get; set; }
    }
}
