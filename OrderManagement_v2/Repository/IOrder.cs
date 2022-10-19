using OrderManagement_v2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement_v2.Repository
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrders();
        Task<int> AddNewOrder(Order order);
        Task<Order> SearchByOrderId(int orderid);
        Task<Order> UpdateOrder(int orderid, Order order);
        Task<List<Order>> SearchByStatus();
      //  Task<int> UpdateStatus(int orderid, Order status);
        Task<int> DeleteOrder(int orderid);
        Task<int> DeleteProduct(int productid);
    }
}
