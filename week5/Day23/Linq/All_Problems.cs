using System;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class ProblemAll
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // 1. Write a LINQ query to search and display all products with category "FMCG"
            var r1 = from p in products
                     where p.ProCategory == "FMCG"
                     select p;

            foreach (var item in r1)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 2. Write a LINQ query to search and display all products with category "Grain"
            var r2 = from p in products
                     where p.ProCategory == "Grain"
                     select p;

            foreach (var item in r2)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 3. Write a LINQ query to sort products in ascending order by product code
            var r3 = from p in products
                     orderby p.ProCode
                     select p;

            foreach (var item in r3)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 4. Write a LINQ query to sort products in ascending order by product Category
            var r4 = from p in products
                     orderby p.ProCategory
                     select p;

            foreach (var item in r4)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 5. Write a LINQ query to sort products in ascending order by product Mrp
            var r5 = from p in products
                     orderby p.ProMrp
                     select p;

            foreach (var item in r5)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 6. Write a LINQ query to sort products in descending order by product Mrp
            var r6 = from p in products
                     orderby p.ProMrp descending
                     select p;

            foreach (var item in r6)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 7. Write a LINQ query to display products group by product Category
            var r7 = from p in products
                     group p by p.ProCategory into g
                     select g;

            foreach (var group in r7)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            Console.WriteLine();

            // 8. Write a LINQ query to display products group by product Mrp
            var r8 = from p in products
                     group p by p.ProMrp into g
                     select g;

            foreach (var group in r8)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
                }
            }
            Console.WriteLine();

            // 9. Write a LINQ query to display product detail with highest price in FMCG category
            var r9 = (from p in products
                      where p.ProCategory == "FMCG"
                      orderby p.ProMrp descending
                      select p).First();

            Console.WriteLine($"{r9.ProCode}\t{r9.ProName}\t{r9.ProCategory}\t{r9.ProMrp}");
            Console.WriteLine();

            // 10. Write a LINQ query to display count of total products
            var r10 = (from p in products
                       select p).Count();
            Console.WriteLine(r10);
            Console.WriteLine();

            // 11. Write a LINQ query to display count of total products with category FMCG
            var r11 = (from p in products
                       where p.ProCategory == "FMCG"
                       select p).Count();
            Console.WriteLine(r11);
            Console.WriteLine();

            // 12. Write a LINQ query to display Max price
            var r12 = (from p in products
                       select p.ProMrp).Max();
            Console.WriteLine(r12);
            Console.WriteLine();

            // 13. Write a LINQ query to display Min price
            var r13 = (from p in products
                       select p.ProMrp).Min();
            Console.WriteLine(r13);
            Console.WriteLine();

            // 14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not
            var r14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine(r14);
            Console.WriteLine();

            // 15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not
            var r15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine(r15);

            Console.ReadLine();
        }
    }
}