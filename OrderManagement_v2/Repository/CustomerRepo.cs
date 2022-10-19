using Microsoft.EntityFrameworkCore;
using OrderManagement_v2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement_v2.Repository
{
    public class CustomerRepo : ICustomer   
    {
        private readonly OrderContext orderContext;

        public CustomerRepo(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }
        public async Task<Customer> Login(string Username, string Password)
        {
            var ar = await orderContext.customers.Where(x => x.Username == Username && x.Password == Password).FirstOrDefaultAsync();
            if (ar != null)
            {
                return ar;
            }
            return null;
        }
    }
}
