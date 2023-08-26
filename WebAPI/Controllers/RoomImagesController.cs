using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomImagesController : ControllerBase
    {
        IRoomImageService _roomImageServices;
        public RoomImagesController(IRoomImageService roomImageServices)
        {
            _roomImageServices = roomImageServices;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _roomImageServices.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("GetByImageId")]
        public IActionResult GetByImageId(int id)
        {
            var result = _roomImageServices.Get(c => c.Id == id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("GetByRoomId")]
        public IActionResult GetByRoomId(int id)
        {
            var result = _roomImageServices.GetAll(c => c.RoomId == id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("UploadImage")]
        public IActionResult UploadImage(IFormFile imageFile, int roomId)
        {
            var result = _roomImageServices.Add2(imageFile, roomId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }





        [HttpPost("Add")]
        public IActionResult Add(RoomImage roomImage)
        {
            var result = _roomImageServices.Add(roomImage);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }




        [HttpPost("DeleteById")]
        public IActionResult Delete(int id)
        {
            var imageToDelete = _roomImageServices.Get(i => i.Id == id).Data;
            var result = _roomImageServices.Delete(imageToDelete);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}

