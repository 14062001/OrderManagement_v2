using Microsoft.EntityFrameworkCore;
using OrderManagement_v2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrderManagement_v2.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly OrderContext orderContext;

        public OrderRepo(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public async Task<int> AddNewOrder(Order order)
        {
            orderContext.orders.Add(order);
            int res = await orderContext.SaveChangesAsync();
            if (res > 0)
            {
                return order.Order_id;
            }
            return 0;
        }

        public async Task<int> DeleteOrder(int orderid)
        {
            var ar = orderContext.orders.Where(x => x.Order_id == orderid).FirstOrDefaultAsync();
            if (ar != null)
            {
                orderContext.orders.Remove(await ar);
                int res = await orderContext.SaveChangesAsync();
                if (res > 0)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public Task<int> DeleteProduct(int productid)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var ar = orderContext.orders.ToListAsync();
            return await ar;
        }

        public async Task<Order> SearchByOrderId(int orderid)
        {
            var ar = orderContext.orders.Where(x => x.Order_id == orderid).FirstOrDefaultAsync();
            if (ar != null)
            {
                return await ar;
            }
            return null;
        }

        public async Task<List<Order>> SearchByStatus()
        {
            var ar = orderContext.orders.Where(x => x.status == "Pending" || x.status == "Confirmed").ToListAsync();
            if (ar != null)
            {
                return await ar;
            }
            return null;
        }

        public async Task<Order> UpdateOrder(int orderid, Order order)
        {
            var data = await orderContext.orders.Where(x => x.Order_id == orderid).FirstOrDefaultAsync();
            if (data != null)
            {
                data.status = order.status;
                data.quantity = order.quantity;
                data.Shipment_date = order.Shipment_date;
                data.Total_Price = order.Total_Price;
                int res = await orderContext.SaveChangesAsync();
                if (res > 0)
                {
                    return data;
                }
                return null;
            }
            return null;
        }
    }
}
