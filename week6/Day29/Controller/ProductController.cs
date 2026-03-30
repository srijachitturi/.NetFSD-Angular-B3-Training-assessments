using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication19.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 75000, Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Mobile", Price = 25000, Category = "Gadgets" },
            new Product { ProductId = 3, ProductName = "Keyboard", Price = 1500, Category = "Computer" },
            new Product { ProductId = 4, ProductName = "Monitor", Price = 12000, Category = "Display" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product proObj = products.FirstOrDefault(item => item.ProductId == id);
            return View(proObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                products.Add(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product proObj = products.FirstOrDefault(item => item.ProductId == id);
            return View(proObj);
        }

        [HttpPost]
        public IActionResult Edit(Product pro)
        {
            if (ModelState.IsValid)
            {
                var existPro = products.FirstOrDefault(x => x.ProductId == pro.ProductId);

                if (existPro != null)
                {
                    existPro.ProductName = pro.ProductName;
                    existPro.Price = pro.Price;
                    existPro.Category = pro.Category;
                }

                return RedirectToAction("Index");
            }

            return View(pro);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product proObj = products.FirstOrDefault(item => item.ProductId == id);
            return View(proObj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Product proObj = products.FirstOrDefault(item => item.ProductId == id);

            if (proObj != null)
            {
                products.Remove(proObj);
            }

            return RedirectToAction("Index");
        }
    }
}