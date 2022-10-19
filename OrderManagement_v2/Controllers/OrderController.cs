using Microsoft.AspNetCore.Mvc;
using OrderManagement_v2.Models;
using OrderManagement_v2.Repository;
using System.Threading.Tasks;

namespace OrderManagement_v2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder orderi;
        private readonly OrderContext orderContext;

        public OrderController(IOrder orderi, OrderContext orderContext)
        {
            this.orderi = orderi;
            this.orderContext = orderContext;
        }
        [HttpGet]
        [Route("orderbyid/{orderid}")]
        public async Task<IActionResult> Productview(int orderid)
        {
            var res = await orderi.SearchByOrderId(orderid);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> ShowAllOrders()
        {
            var ar = await orderi.GetAllOrders();
            if (ar != null)
            {
                return Ok(ar);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("updateorder/{id}")]
        public async Task<IActionResult> update(int id, [FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                var res = await orderi.UpdateOrder(id, order);
                if (res != null)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpGet]
        [Route("orderbystatus")]
        public async Task<IActionResult> Statusview()
        {

            var res = await orderi.SearchByStatus();
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("AddnewOrder")]
        public async Task<IActionResult> AddOrder([FromBody]Order order)
        {
            if (ModelState.IsValid)
            {


                int res = await orderi.AddNewOrder(order);
                if (res > 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("DeleteOrder/{orderid}")]
        public async Task<IActionResult> DeleteManager(int orderid)
        {
            int res = await orderi.DeleteOrder(orderid);
            if (res > 0)
            {
                return Ok(res);
            }
            return NotFound();
        }
        
    }
}
