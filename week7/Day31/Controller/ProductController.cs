using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication4.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        public class ProductItem
        {
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = new List<ProductItem>();
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(
            string productName,
            decimal price,
            int quantity,
            List<string>? oldProductName,
            List<decimal>? oldPrice,
            List<int>? oldQuantity)
        {
            List<ProductItem> products = new List<ProductItem>();

            if (oldProductName != null && oldPrice != null && oldQuantity != null)
            {
                for (int i = 0; i < oldProductName.Count; i++)
                {
                    products.Add(new ProductItem
                    {
                        ProductName = oldProductName[i],
                        Price = oldPrice[i],
                        Quantity = oldQuantity[i]
                    });
                }
            }

            if (string.IsNullOrWhiteSpace(productName) || productName.Trim().Length < 2)
            {
                ViewBag.Products = products;
                ViewBag.Error = "Product name must be at least 2 characters.";
                return View("Index");
            }

            if (price < 1 || price > 10000)
            {
                ViewBag.Products = products;
                ViewBag.Error = "Price must be between 1 and 10000.";
                return View("Index");
            }

            if (quantity < 1 || quantity > 1000)
            {
                ViewBag.Products = products;
                ViewBag.Error = "Quantity must be between 1 and 1000.";
                return View("Index");
            }

            products.Add(new ProductItem
            {
                ProductName = productName.Trim(),
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = products;
            return View("Index");
        }
    }
}
