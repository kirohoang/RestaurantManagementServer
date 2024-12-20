using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly FinalTermContext orderDetailsContext;

        public OrderDetailsController(FinalTermContext orderDetailsContext)
        {
            this.orderDetailsContext = orderDetailsContext;
        }

        [HttpGet]
        public IActionResult getOrderDetails()
        {
            var orderDetails = orderDetailsContext.OrderDetails.ToList();

            return Ok(orderDetails);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getOrderDetailsById(int id)
        {
            var orderDetails = orderDetailsContext.OrderDetails.Find(id);

            if (orderDetails is null)
            {
                return NotFound("Order details doesn't exist");
            }
            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult addOrderDetails(AddOrderDetailsDto addOrderDetailsDto)
        {
            var orderDetails = new OrderDetail()
            {
                OrderId = addOrderDetailsDto.OrderId,
                ProductName = addOrderDetailsDto.ProductName,
                Quantity = addOrderDetailsDto.Quantity,
                Price = addOrderDetailsDto.Price,
            };
            orderDetailsContext.OrderDetails.Add(orderDetails);
            orderDetailsContext.SaveChanges();
            return Ok(orderDetails);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateOrderDetails(int id, UpdateOrderDetailsDto updateOrderDetailsDto)
        {
            var orderDetails = orderDetailsContext.OrderDetails.Find(id);

            if (orderDetails is null)
            {
                return NotFound("Order details doesn't exists");
            }

            orderDetails.ProductName = updateOrderDetailsDto.ProductName;
            orderDetails.Quantity = updateOrderDetailsDto.Quantity;
            orderDetails.Price = updateOrderDetailsDto.Price;

            orderDetailsContext.SaveChanges();

            return Ok(orderDetails);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteOrderDetails(int id)
        {
            var orderDetails = orderDetailsContext.OrderDetails.Find(id);

            if (orderDetails is null)
            {
                return NotFound("Order details doesn't exists");
            }

            orderDetailsContext.OrderDetails.Remove(orderDetails);
            orderDetailsContext.SaveChanges();
            return Ok(orderDetails);
        }
    }
}
