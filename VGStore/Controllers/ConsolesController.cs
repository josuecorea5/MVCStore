using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGStore.Data;
using VGStore.Models;

namespace VGStore.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly AppDbContext _db;
        public ConsolesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Consoles> objList = _db.Consoles;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consoles obj)
        {
            if(ModelState.IsValid)
            {
                _db.Consoles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        { 
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Consoles.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Consoles obj)
        {
            if(ModelState.IsValid)
            {
                _db.Consoles.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE - GET
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Consoles.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? IdConsole)
        {
            var obj = _db.Consoles.Find(IdConsole);
            _db.Consoles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
