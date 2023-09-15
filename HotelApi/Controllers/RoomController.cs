using HotelApi.Data;
using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Repository.Abastract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly DatabaseContext _context;
        private readonly IRoomRepository _roomRepo;
        public RoomController(IFileService fs, IRoomRepository roomRepo,DatabaseContext context)
        {
            this._fileService = fs;
            this._roomRepo = roomRepo;
            this._context = context;
        }
        [HttpPost]
        public IActionResult Add([FromForm] Room model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    model.Image = fileResult.Item2; // getting name of image
                }
                var roomResult = _roomRepo.Add(model);
                if (roomResult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error on adding room";

                }
            }
            return Ok(status);

        }

        [HttpGet]
        public List<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, [FromForm] Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (room.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(room.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    room.Image = fileResult.Item2; // getting name of image
                }
                _context.Entry(room).State = EntityState.Modified;
            }
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            _fileService.DeleteImage(room.Image);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(r => r.Id == id);
        }
    }
}
