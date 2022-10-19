using OrderManagement_v2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement_v2.Repository
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> SearchByProductName(string productname);
        Task<int> AddNewProduct(Product product);
        Task<List<Product>> SearchByOrderid(int orderid);
        Task<int> UpdateOrderid(int productid, Product orderid);
    }
}
