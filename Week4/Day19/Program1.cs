using System;

namespace ConsoleApp4
{
    class Product
    {
        // Private variables
        private int _productId;
        private string _productName;
        private double _unitPrice;
        private int _qty;

        // Constructor - productId as parameter
        public Product(int productId)
        {
            _productId = productId;
            _productName = string.Empty;
            _unitPrice = 0.0;
            _qty = 0;
        }

        public int ProductId
        {
            get { return _productId; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public void ShowDetails()
        {
            double totalAmount = _unitPrice * _qty;
            Console.WriteLine($"Product ID  : {ProductId}");
            Console.WriteLine($"Product Name: {ProductName}");
            Console.WriteLine($"Unit Price  : {UnitPrice}");
            Console.WriteLine($"Quantity    : {Quantity}");
            Console.WriteLine($"Total Amount: {totalAmount}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Product p1 = new Product(501);
            p1.ProductName = "Mechanical Keyboard";
            p1.UnitPrice = 2500.00;
            p1.Quantity = 3;

            p1.ShowDetails();

            Console.ReadLine();
        }
    }
}