using Microsoft.AspNetCore.Mvc;
using RestaurantManagementServer.Data;
using RestaurantManagementServer.Models.Dto.Add;
using RestaurantManagementServer.Models.Dto.Update;
using RestaurantManagementServer.Models.Entities;

namespace RestaurantManagementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly FinalTermContext seatContext;

        public SeatsController(FinalTermContext seatContext)
        {
            this.seatContext = seatContext;
        }

        [HttpGet]
        public IActionResult getSeats()
        {
            var seat = seatContext.Seats.ToList();
            return Ok(seat);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getSeatById(int id)
        {
            var seat = seatContext.Seats.Find(id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        [HttpPost]
        public IActionResult addSeat(AddSeatDto addSeatDto)
        {
            var seat = new Seat()
            {
                BranchId = addSeatDto.BranchId,
                Status = addSeatDto.Status,
            };

            seatContext.Seats.Add(seat);
            seatContext.SaveChanges();
            return Ok(seat);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateSeat(int id, UpdateSeatDto updateSeatDto)
        {
            var seat = seatContext.Seats.Find(id);

            if (seat == null)
            {
                return NotFound("This seat is not existed");
            }

            seat.BranchId = updateSeatDto.BranchId;
            seat.Status = updateSeatDto.Status;

            seatContext.SaveChanges();
            return Ok(seat);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteSeatById(int id)
        {
            var seat = seatContext.Seats.Find(id);

            if (seat is null)
            {
                return NotFound();
            }
            seatContext.Seats.Remove(seat);
            seatContext.SaveChanges();
            return Ok("Remove Successfully");
        }
    }
}
