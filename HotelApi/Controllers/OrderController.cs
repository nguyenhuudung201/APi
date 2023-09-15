using HotelApi.Data;
using HotelApi.Migrations;
using HotelApi.Models;
using HotelApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrder()
        {
            var orders = (from o in _context.Bookings
                             join r in _context.Rooms on o.RoomId equals r.Id
                          join u in _context.Users on o.UserId equals u.Id

                          select new OrderDto
                             {
                                 UserName = u.Username,
                                 RoomName = r.Name,
                                 Total = o.Total,
                                 CheckIn= o.CheckIn,
                                 CheckOut= o.ChecKOut,
                                 Adult = o.Adult,
                                 Child= o.Child,
                                 OrderStatus= o.OrderStatus,
                                 Request = o.Request,
                             }
                            ).ToListAsync();
            return await orders;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Booking booking)
        {
            booking.OrderStatus = "Pending";
            int userId = booking.UserId - '0';
            booking.UserId = userId;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = booking.Id }, booking);
        }
    }
}
