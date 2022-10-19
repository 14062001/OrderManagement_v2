using OrderManagement_v2.Models;
using System.Threading.Tasks;

namespace OrderManagement_v2.Repository
{
    public interface ICustomer
    {
        Task<Customer> Login(string username, string password);

    }
}
