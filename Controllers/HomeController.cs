using Microsoft.AspNetCore.Mvc;
using SupplierApp.Concrete.EF.Contexts;
using SupplierApp.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SupplierApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View(DbGetAll());
        }

        // GET-Insert
        public IActionResult Insert()
        {
            return View();
        }

        // POST-Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                DbInsert(obj);
                return RedirectToAction("Index");
            }

            return View(obj);

        }




        // GET-Update
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var obj = DbGetById(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }


        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                DbUpdate(obj);
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IEnumerable<Supplier> DbGetAll()
        {
            using var context = new AppDbContext();

            return context.Set<Supplier>().ToList();
        }

        public Supplier DbGetById(Expression<Func<Supplier, bool>> filter)
        {
            using var context = new AppDbContext();

            return context.Set<Supplier>().Where(filter).SingleOrDefault();
        }

        public void DbInsert(Supplier entity)
        {
            using var context = new AppDbContext();

            context.AddAsync(entity);
            context.SaveChanges();
        }


        public void DbUpdate(Supplier entity)
        {
            using var context = new AppDbContext();

            context.Update(entity);
            context.SaveChanges();
        }
    }
}
