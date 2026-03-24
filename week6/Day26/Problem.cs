using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ProductApp
{
    internal class Program
    {
        static void Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString =
                config.GetConnectionString("DefaultConnection");

            while (true)
            {
                Console.WriteLine("\n1.Insert 2.View 3.Update 4.Delete 5.Exit");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) InsertProduct(connectionString);
                else if (choice == 2) ViewProducts(connectionString);
                else if (choice == 3) UpdateProduct(connectionString);
                else if (choice == 4) DeleteProduct(connectionString);
                else return;
            }
        }

        // INSERT
        static void InsertProduct(string cs)
        {
            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            using SqlConnection con = new SqlConnection(cs);
            using SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(
                new SqlParameter("@ProductName", SqlDbType.VarChar, 100) { Value = name });

            cmd.Parameters.Add(
                new SqlParameter("@Category", SqlDbType.VarChar, 50) { Value = category });

            cmd.Parameters.Add(
                new SqlParameter("@Price", SqlDbType.Decimal)
                { Precision = 10, Scale = 2, Value = price });

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Inserted Successfully");
        }

        // VIEW
        static void ViewProducts(string cs)
        {
            using SqlConnection con = new SqlConnection(cs);
            using SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con);

            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nId\tName\tCategory\tPrice");

            while (reader.Read())
            {
                Console.WriteLine(
                    $"{reader["ProductId"]}\t{reader["ProductName"]}\t{reader["Category"]}\t{reader["Price"]}");
            }
        }

        // UPDATE
        static void UpdateProduct(string cs)
        {
            Console.Write("Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Name: ");
            string name = Console.ReadLine();

            Console.Write("New Category: ");
            string category = Console.ReadLine();

            Console.Write("New Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            using SqlConnection con = new SqlConnection(cs);
            using SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(
                new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

            cmd.Parameters.Add(
                new SqlParameter("@ProductName", SqlDbType.VarChar, 100) { Value = name });

            cmd.Parameters.Add(
                new SqlParameter("@Category", SqlDbType.VarChar, 50) { Value = category });

            cmd.Parameters.Add(
                new SqlParameter("@Price", SqlDbType.Decimal)
                { Precision = 10, Scale = 2, Value = price });

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Updated Successfully");
        }

        // DELETE
        static void DeleteProduct(string cs)
        {
            Console.Write("Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using SqlConnection con = new SqlConnection(cs);
            using SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(
                new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Deleted Successfully");
        }
    }
}
