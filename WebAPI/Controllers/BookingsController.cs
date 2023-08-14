using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.DataResult;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        IBookingService _bookingService;

        public BookingsController(IBookingService bookingsService)
        {
            _bookingService = bookingsService;
        }




        [HttpPost("Add")]
        public IActionResult Add(Booking booking)
        {
            var result = _bookingService.Add(booking);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Booking booking)
        {
            var result = _bookingService.Delete(booking);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Booking booking)
        {
            var result = _bookingService.Update(booking);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("CheckIn")]
        public IActionResult CheckIn(Booking booking)
        {
            var result = _bookingService.CheckIn(booking);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CheckOut")]
        public IActionResult CheckOut(int bookingId, DateTime checkOutDate)
        {
            var result = _bookingService.CheckOut(bookingId, checkOutDate);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCheckInDate")]

        public IActionResult GetByCheckInDate(DateTime minDate, DateTime maxDate)
        {
            var result = _bookingService.GetAll(b => b.CheckInDate > minDate && b.CheckInDate < maxDate);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            var result = _bookingService.Get(b => b.Id == id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByRoomId")]

        public IActionResult GetByRoomId(int roomId)
        {
            var result = _bookingService.GetAll(b => b.RoomId == roomId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _bookingService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }







    }
}
