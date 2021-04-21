using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public  IActionResult Index()
        {
            IEnumerable<Category> objectList = _db.CategoryTbl;

            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Category obj)
        {
            if (!ModelState.IsValid) return View(obj);

            _db.CategoryTbl.Add(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var userObject = _db.CategoryTbl.Find(id);

            if(userObject == null)
            {
                return NotFound();
            }

            return View(userObject);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (!ModelState.IsValid) return View(obj);

            _db.CategoryTbl.Update(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var userObject = _db.CategoryTbl.Find(id);

            if (userObject == null)
            {
                return NotFound();
            }

            return View(userObject);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var objectId = _db.CategoryTbl.Find(id);

            if (objectId == null) return NotFound();

            _db.CategoryTbl.Remove(objectId);

            _db.SaveChanges();

            return RedirectToAction("Index");


        }

    }
}
