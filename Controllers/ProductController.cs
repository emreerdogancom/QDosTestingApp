using Microsoft.AspNetCore.Mvc;
using SupplierApp.Concrete.EF.Contexts;
using SupplierApp.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SupplierApp.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
        }

        public IActionResult Index()
        {
            return View(GetAll());
        }

        public IActionResult Insert()
        {
            return View();
        }

        // POST-Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Product obj)
        {
            if (ModelState.IsValid)
            {
                DbInsert(obj);
                return RedirectToAction("Index");
            }

            return View(obj);

        }


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



        // POST-Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product obj)
        {
            if (ModelState.IsValid)
            {
                DbUpdate(obj);
                return RedirectToAction("Index");
            }

            return View(obj);

        }



        public void DbUpdate(Product entity)
        {
            using var context = new AppDbContext();

            context.Update(entity);
            context.SaveChanges();
        }




        public IEnumerable<Product> GetAll()
        {
            using var context = new AppDbContext();

            return context.Set<Product>().ToList();       
        }


        public void DbInsert(Product entity)
        {
            using var context = new AppDbContext();

            context.AddAsync(entity);
            context.SaveChanges();
        }


        public Product DbGetById(Expression<Func<Product, bool>> filter)
        {
            using var context = new AppDbContext();

            return context.Set<Product>().Where(filter).SingleOrDefault();
        }
    }
}
