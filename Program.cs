namespace _20241119_LINQ_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            // Demo1();
            // Demo2();

            //Demo3();

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //var numberGroups = from n in numbers
            //                   group n by n % 5 into g
            //                   select (Remainder: g.Key, Numbers: g);

            var numberGroups = numbers
                    .GroupBy(n => n % 5)
                    .Select(res => new { Remainder = res.Key, Numbers = res });

            foreach (var g in numberGroups)
            {
                Console.WriteLine($"Numbers with a remainder of {g.Remainder} when divided by 5:");
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }

        }

        private static void Demo3()
        {
            //foreach (var p in Products.ProductList) 
            //{
            //    Console.WriteLine(p);
            //}

            string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            List<Product> products = Products.ProductList;

            //var q = from c in categories
            //        join p in products on c equals p.Category
            //        select (Category: c, p.ProductName);

            var q = categories
                    .Join(products, c => c, p => p.Category,
                            (c, p) => new { Category = c, p.ProductName });


            foreach (var v in q)
            {
                Console.WriteLine(v.ProductName + ": " + v.Category);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            var productsOfBeverages = products
                    .Where(p => p.Category == "Beverages" && p.UnitPrice >= 20);

            //var productsOfBeverages = from p in products
            //                          where p.Category == "Beverages" && p.UnitPrice <= 20
            //                          select p;

            foreach (var p in productsOfBeverages)
            {
                Console.WriteLine(p);
            }
        }

        private static void Demo2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // query mode
            //var numsPlusOne = from n in numbers
            //                  select n + 1;
            var numsPlusOne = numbers
                    .Select(n => n + 1);

            Console.WriteLine("Numbers + 1:");
            foreach (var i in numsPlusOne)
            {
                Console.WriteLine(i);
            }
        }

        private static void Demo1()
        {
            var k = 12.7;

            Console.WriteLine(k);

            var obj1 = new { f1 = 3, f2 = "test", f3 = 4.21 };

            Console.WriteLine(obj1);

            {
                int data = 7;

                int result = Utility.Sqr(data);

                Console.WriteLine(result);
            }


            {
                int data = 7;

                int result = data.Sqr();

                Console.WriteLine(result);
            }

            List<double> src = new List<double> { 1.5, -6.71, 9.12 };

            var dest1 = Utility.DoDouble(src);
            IEnumerable<double> dest2 = Utility.DoDouble(src);

            IEnumerable<double> dest3 = Utility.DoDouble(Utility.DoDouble(src));

            Console.WriteLine("dest1:");
            foreach (var d in dest1)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("src.DoDouble():");
            foreach (var d in src.DoDouble())
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("src.DoDouble().DoDouble():");
            foreach (var d in src.DoDouble().DoDouble())
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //double res = Array.Find(src, IsLessZerro);

            //double res2 = Array.Find(src, n => n < 0.0);


            #region Lazy loading

            var dest10 = src.DoDouble().DoDouble();    // Збереження структури запиту
            var dest11 = src.DoDouble().DoDouble().ToList();    // Збереження копії

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("dest10:");
            foreach (var d in dest10)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            src.Add(7.2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("dest10:");
            foreach (var d in dest10)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            #endregion
        }

        public static bool IsLessZerro(double n)
        {
            return n < 0.0;
        }
    }
}