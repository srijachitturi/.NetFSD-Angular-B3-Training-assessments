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

        // Constructor allowing productId as parameter
        public Product(int productId)
        {
            this._productId = productId;
            this._productName = string.Empty;
            this._unitPrice = 0.0;
            this._qty = 0;
        }

        // ProductId – readonly property
        public int ProductId
        {
            get { return this._productId; }
        }

        // Properties for all private variables
        public string ProductName
        {
            get { return this._productName; }
            set { this._productName = value; }
        }

        public double UnitPrice
        {
            get { return this._unitPrice; }
            set { this._unitPrice = value; }
        }

        public int Quantity
        {
            get { return this._qty; }
            set { this._qty = value; }
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