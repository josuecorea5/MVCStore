using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VGStore.Data;
using VGStore.Models;
using VGStore.Models.ViewModels;

namespace VGStore.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductosController(AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Productos> objList = _db.Productos;
            foreach(var obj in objList)
            {
                obj.Categoria = _db.Categories.FirstOrDefault(u => u.IdCategory == obj.IdCategory);
            }
            return View(objList);
        }


        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            ProductosVM productoVM = new ProductosVM()
            {
                Productos = new Productos(),
                CategoriasSelectList = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.IdCategory.ToString()
                }),
            };
            if (id == null)
            {
                //parte de creacion de producto
                return View(productoVM);
            }
            else
            {
                //parte de la edicion
                productoVM.Productos = _db.Productos.Find(id);
                if(productoVM.Productos == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }
            
        }
        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductosVM productosVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webrootPath = _webHostEnvironment.WebRootPath;
                if(productosVM.Productos.IdProducto == 0)
                {
                    //crear
                    string upload = webrootPath + WC.ProductosPath; // nueva ubicacion del archivo
                    string fileName = Guid.NewGuid().ToString(); //nombre generado al random
                    string extension = Path.GetExtension(files[0].FileName);//extraer extencion del archivo

                    using(var filestream = new FileStream(Path.Combine(upload,fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }

                    productosVM.Productos.Imagen = fileName + extension;

                    _db.Productos.Add(productosVM.Productos);

                }else
                {
                    //editar
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        //DELETE - GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? IdCategory)
        {
            var obj = _db.Categories.Find(IdCategory);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

