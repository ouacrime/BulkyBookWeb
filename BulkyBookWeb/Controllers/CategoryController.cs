using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _Db;

        public CategoryController(ApplicationDbContext Db)
        {
            _Db = Db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoeyList = _Db.Categories;

            return View(objCategoeyList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Categories.Add(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }



    }
}
