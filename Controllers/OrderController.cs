using BookStoreWebApi.Models;
using BookStoreWebApi.Packages;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        //[HttpPost]
        //public void AddOrder(Order order)
        //{
        //    var package = new PKG_ORDER();
        //    package.add_order(order);
        //}
        [HttpPost]
        public IActionResult AddOrders([FromBody] List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                return BadRequest(new { message = "No orders provided." });
            }

            try
            {
                var package = new PKG_ORDER();
                foreach (var order in orders)
                {
                    package.add_order(order);
                }

                return Ok(new { message = "Orders placed successfully." }); // Return JSON object
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" }); // Return error as JSON
            }
        }




        //[HttpGet("{fullName}")]
        //public void GetOrderByFullname(string fullName)
        //{
        //    var package = new PKG_ORDER();

        //}

        [HttpGet("{fullName}")]
        public IActionResult GetOrderByFullname(string fullName)
        {
            try
            {
                var package = new PKG_ORDER();
                var orders = package.get_order_by_fulname(fullName); // Call the stored procedure to fetch orders

                if (orders == null || orders.Count == 0)
                {
                    return NotFound($"No orders found for fullname: {fullName}");
                }

                return Ok(orders); // Return the orders as JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            var package = new PKG_ORDER();
            Order order = new Order();
            order.Id = id;
            package.delete_order(order);
        }


    }
}
