using System;

namespace ShoppingCartApp
{
    public class Product
    {
 
        private string _name;
        private double _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //  Encapsulation: Prevent negative price assignment
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative.");
                    _price = 0;
                }
                else
                {
                    _price = value;
                }
            }
        }

        public Product(string name, double price)
        {
            _name = name;
            Price = price; 
        }

        //  Virtual method for discount (Polymorphism)
        public virtual double CalculateDiscount()
        {
            return 0;
        }
    }
    public class Electronics : Product
    {
        public Electronics(string name, double price) : base(name, price) { }

        // Electronics 5% discount
        public override double CalculateDiscount()
        {
            return Price * 0.05;
        }
    }

    public class Clothing : Product
    {
        public Clothing(string name, double price) : base(name, price) { }

        // Clothing 15% discount
        public override double CalculateDiscount()
        {
            return Price * 0.15;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
     
            Product cartItem = new Electronics("Laptop", 20000);

            double discount = cartItem.CalculateDiscount();
            double finalPrice = cartItem.Price - discount;

            Console.WriteLine($"Final Price after 5% discount = {finalPrice}");
        }
    }
}