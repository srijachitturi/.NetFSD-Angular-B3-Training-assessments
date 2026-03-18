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

            // 1. FMCG category
            var r1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in r1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            // 2. Grain category
            var r2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in r2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            // 3. Sort by Product Code
            var r3 = products.OrderBy(p => p.ProCode);
            foreach (var item in r3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            // 4. Sort by Category
            var r4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in r4)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}\t{item.ProMrp}");
            Console.WriteLine();

            // 5. Sort by MRP Asc
            var r5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in r5)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            // 6. Sort by MRP Desc
            var r6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in r6)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            Console.WriteLine();

            // 7. Group by Category
            var r7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in r7)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine();

            // 8. Group by MRP
            var r8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in r8)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
            }
            Console.WriteLine();

            // 9. Highest price in FMCG
            var r9 = products
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .First();

            Console.WriteLine($"{r9.ProCode}\t{r9.ProName}\t{r9.ProCategory}\t{r9.ProMrp}");
            Console.WriteLine();

            // 10. Total products count
            Console.WriteLine(products.Count());
            Console.WriteLine();

            // 11. FMCG count
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));
            Console.WriteLine();

            // 12. Max price
            Console.WriteLine(products.Max(p => p.ProMrp));
            Console.WriteLine();

            // 13. Min price
            Console.WriteLine(products.Min(p => p.ProMrp));
            Console.WriteLine();

            // 14. All below Rs.30
            Console.WriteLine(products.All(p => p.ProMrp < 30));
            Console.WriteLine();

            // 15. Any below Rs.30
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}