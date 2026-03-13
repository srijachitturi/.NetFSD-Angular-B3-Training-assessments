using System;

namespace ConsoleApp4
{
    internal class Employee
    {
        private string _fullName;
        private int _age;
        private decimal _salary;
        private string _employeeId;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Full Name cannot be null, empty, or whitespace.");
                }

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 18 || value > 80)
                {
                    throw new ArgumentException("Age must be between 18 and 80.");
                }

                _age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Salary cannot be less than 1000.");
                }

                _salary = value;
            }
        }

        public string EmployeeId
        {
            get
            {
                return _employeeId;
            }
        }

        public Employee(string fullName, decimal salary, int age)
        {

            _fullName = fullName;
            _age = age;
            _salary = salary;
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
            {
                throw new ArgumentException("Raise percentage must be greater than 0 and less than or equal to 30.");
            }

            Salary = Salary + (Salary * percentage / 100);
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (Salary - amount < 1000)
            {
                return false;
            }

            Salary = Salary - amount;
            return true;
        }
    }
}