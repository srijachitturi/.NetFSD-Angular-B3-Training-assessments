using System;

namespace VehicleRentalApp
{
    public class Vehicle
    {
        private string _brand;
        private double _rentalRatePerDay;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public double RentalRatePerDay
        {
            get { return _rentalRatePerDay; }
            set { _rentalRatePerDay = value; }
        }

        public Vehicle(string brand, double rentalRatePerDay)
        {
            _brand = brand;
            _rentalRatePerDay = rentalRatePerDay;
        }

        // Virtual method for overriding
        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days.");
                return 0;
            }
            return RentalRatePerDay * days;
        }
    }

    public class Car : Vehicle
    {
        public Car(string brand, double rentalRatePerDay) : base(brand, rentalRatePerDay) { }

        // Car adds insurance charge of 500 per rental
        public override double CalculateRental(int days)
        {
            if (days <= 0) return 0;
            return (RentalRatePerDay * days) + 500;
        }
    }

    public class Bike : Vehicle
    {
        public Bike(string brand, double rentalRatePerDay) : base(brand, rentalRatePerDay) { }

        // Bike offers 5% discount on total rental
        public override double CalculateRental(int days)
        {
            if (days <= 0) return 0;
            double total = RentalRatePerDay * days;
            return total * 0.95; // 5% discount
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Sample Input: Car, Rate=2000, Days=3
            // Apply runtime polymorphism 
            Vehicle myRental = new Car("Toyota", 2000);
            int days = 3;

            double total = myRental.CalculateRental(days);

            Console.WriteLine($"Total Rental = {total}");
        }
    }
}