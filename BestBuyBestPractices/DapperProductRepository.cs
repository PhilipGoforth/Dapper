using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                                "VALUES (@name, @price, @categoryID);"
                , new { name = name, price = price, categoryID = categoryID });
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }
    }
}
