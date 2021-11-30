using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        
    }
}
