using Microsoft.AspNetCore.Mvc;
using OrderManagement_v2.Models;
using OrderManagement_v2.Repository;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OrderManagement_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct prod;
        private readonly OrderContext orderContext;

        public ProductController(IProduct prod, OrderContext orderContext)
        {
            this.prod = prod;
            this.orderContext = orderContext;
        }
        [HttpGet]
        [Route("orderedproducts/{orderid}")]
        public async Task<IActionResult> Statusview(int orderid)
        {
            var res = await prod.SearchByOrderid(orderid);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> ShowAllProducts()
        {
            var ar = await prod.GetAllProducts();
            if (ar != null)
            {
                return Ok(ar);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("productview/{productname}")]
        public async Task<IActionResult> Productview(string productname)
        {
            var res = await prod.SearchByProductName(productname);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("updateorder/{productid}")]
        public async Task<IActionResult> DeleteProduct(int productid, Product p)
        {
            if (ModelState.IsValid)
            {
                int res = await prod.UpdateOrderid(productid, p);
                if (res > 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {


                int res = await prod.AddNewProduct(product);
                if (res > 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();

        }
    }
}
