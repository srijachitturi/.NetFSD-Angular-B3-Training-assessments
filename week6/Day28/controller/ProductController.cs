using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>
        {
            new Product { Pid = 1, Pname = "Laptop", Price = 75000, Qty = 5 },
            new Product { Pid = 2, Pname = "Mobile", Price = 30000, Qty = 10 },
            new Product { Pid = 3, Pname = "Tablet", Price = 25000, Qty = 7 },
            new Product { Pid = 4, Pname = "Smart Watch", Price = 12000, Qty = 12 },
            new Product { Pid = 5, Pname = "Headphones", Price = 2000, Qty = 20 },
           
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var p = products.FirstOrDefault(x => x.Pid == id);
            return View(p);
        }
    }
}
