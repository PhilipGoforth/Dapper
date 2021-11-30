using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;



namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);
            
            Console.WriteLine("Enter new department");
            
            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            var repos = new DapperProductRepository(conn);

            Console.WriteLine("Enter Product");

            var newProductName = Console.ReadLine();

            Console.WriteLine("Enter Price");

            var newProductPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Category ID");

            var newProductID = Convert.ToInt32(Console.ReadLine());

            repos.CreateProduct(newProductName, newProductPrice, newProductID);

            var products = repos.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Price} {product.ProductID}");
            }

        }
    }
}
