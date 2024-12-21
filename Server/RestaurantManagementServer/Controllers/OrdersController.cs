using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly FinalTermContext orderContext;

        public OrdersController(FinalTermContext orderContext)
        {
            this.orderContext = orderContext;
        }

        [HttpGet]
        public IActionResult getOrder()
        {
            var order = orderContext.Orders.ToList();

            return Ok(order);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getOrderById(int id)
        {
            var orders = orderContext.Orders.Find(id);

            if (orders is null)
            {
                return NotFound("This order is not exist");
            }

            return Ok(orders);
        }

        [HttpPost]
        public IActionResult addOrder(AddOrderDto addOrderDto)
        {
            var order = new Order()
            {
                CustomerId = addOrderDto.CustomerId,
                ProductId = addOrderDto.ProductId,
                SeatId = addOrderDto.SeatId,
                BranchId = addOrderDto.BranchId,
                OrderDate = addOrderDto.OrderDate,
                Ispayment = addOrderDto.Ispayment,
                PaymentMethod = addOrderDto.PaymentMethod,
            };

            orderContext.Orders.Add(order);
            orderContext.SaveChanges();
            return Ok(order);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = orderContext.Orders.Find(id);

            if (updateOrderDto is null)
            {
                return NotFound("Order doesn't exist");
            }
            order.Ispayment = updateOrderDto.Ispayment;
            order.PaymentMethod = updateOrderDto.PaymentMethod;

            orderContext.SaveChanges();
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteOrder(int id)
        {
            var order = orderContext.Orders.Find(id);

            if (order is null)
            {
                return NotFound("Order doesn't exist");
            }

            orderContext.Orders.Remove(order);
            orderContext.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}
