using Microsoft.EntityFrameworkCore;
using OrderManagement_v2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement_v2.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly OrderContext orderContext;

        public ProductRepo(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }
        public async Task<int> AddNewProduct(Product product)
        {
            orderContext.products.Add(product);
            int res = await orderContext.SaveChangesAsync();
            if (res > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var ar = orderContext.products.ToListAsync();
            return await ar;
        }

        public async Task<List<Product>> SearchByOrderid(int orderid)
        {
            var ar = orderContext.products.Where(x => x.Order_id == orderid).ToListAsync();
            if (ar != null)
            {
                return await ar;
            }
            return null;
        }

        public async Task<Product> SearchByProductName(string Product_name)
        {
            var ar = orderContext.products.Where(x => x.Product_name == Product_name).FirstOrDefaultAsync();
            if (ar != null)
            {
                return await ar;
            }
            return null;
        }

        public async Task<int> UpdateOrderid(int productid, Product p)
        {
            var data = await orderContext.products.Where(x => x.Product_id == productid).FirstOrDefaultAsync();
            if (data != null)
            {
               
                data.Order_id = p.Order_id;
                int res = await orderContext.SaveChangesAsync();
                if (res > 0)
                {
                    return (int)p.Order_id;
                }
                return 0;
            }
            return 0;
        }
    }
}
