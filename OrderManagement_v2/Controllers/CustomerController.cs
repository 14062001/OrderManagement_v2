using Microsoft.AspNetCore.Mvc;
using OrderManagement_v2.Models;
using OrderManagement_v2.Repository;
using System.Threading.Tasks;

namespace OrderManagement_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer cust;
        private readonly OrderContext orderContext;

        public CustomerController(ICustomer cust, OrderContext orderContext)
        {
            this.cust = cust;
            this.orderContext = orderContext;
        }

        [HttpGet]
        [Route("login/{username}/{password}")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var res = await cust.Login(username, password);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
    }
}
