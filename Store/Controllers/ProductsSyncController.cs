using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Utils;

namespace Store.Controllers
{
    public class ProductsSyncController : Controller
    {
        private readonly StoreContext _context;
        public ProductsSyncController(StoreContext contex)
        {
            _context = contex;
        }
        // GET: ProductsSync
        public ActionResult Index()
        {
            return View(_context.Product.ToList());
        }

        // GET: ProductsSync/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product
                .FirstOrDefault(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsSync/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsSync/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ProductID,Name,Description,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                //return View(_context.Product.ToList());
            }
            return View(product);
        }

        // GET: ProductsSync/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductsSync/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ProductID,Name,Description,Price,Category")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Product
                .FirstOrDefault(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Product.Find(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            //var productOrder = new CartLine { Product = new Product { Name = "dgfdsg", Price = 25 }, Quantity = 1 };
            //Repository.AddResponse(productOrder);
            return View(Repository.Responses);
        }
        [HttpPost]
        public ViewResult RsvpForm([Bind("ProductID,Name,Description,Price,Category")]CartLine cartResponse)
        {
            Repository.AddResponse(cartResponse);
            return View(Repository.Responses);
        }
    }
}