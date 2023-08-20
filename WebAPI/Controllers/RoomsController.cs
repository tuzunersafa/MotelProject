using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _roomService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _roomService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

      

        [HttpPost("Add")]
        public IActionResult Add(Room room)
        {
            var result = _roomService.Add(room);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Room room)
        {
            var result = _roomService.Delete(room);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Room room)
        {
            var result = _roomService.Update(room);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
