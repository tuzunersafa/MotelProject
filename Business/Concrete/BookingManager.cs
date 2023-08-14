using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookingManager : IBookingService
    {
        IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }


        public IResult Update(Booking booking)
        {
            _bookingDal.Update(booking);
            return new SuccessResult(Messages.Updated);
        }
        public IResult Delete(Booking booking)
        {
            _bookingDal.Delete(booking);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Add(Booking booking)
        {
            _bookingDal.Add(booking);
            return new SuccessResult(Messages.Added);
        }

        public IResult CheckIn(Booking booking)
        {
            var result = _bookingDal.Get(b => b.Id == booking.Id && b.CheckOutDate == default);
            if (result == null)
            {
                _bookingDal.Add(booking);
                return new SuccessResult(Messages.CheckedIn);
            }
            else
            {
                return new ErrorResult(Messages.RoomInUse);
            }
        }

        public IResult CheckOut(int bookingId, DateTime checkOutDate)
        {
            var booking = _bookingDal.Get(b => b.Id == bookingId && b.CheckOutDate == default);
            if (booking != null)
            {
                booking.CheckOutDate = checkOutDate;
                _bookingDal.Update(booking);
                return new SuccessResult(Messages.CheckedOut);

            }
            return new ErrorResult(Messages.NotFound);


        }

        public IDataResult<Booking> Get(Expression<Func<Booking, bool>> filter)
        {
            var result = _bookingDal.Get(filter);
            if (result == null)
            {
                return new ErrorDataResult<Booking>(Messages.NotFound);
            }
            return new SuccessDataResult<Booking>(result, Messages.Listed);
        }

        public IDataResult<List<Booking>> GetAll(Expression<Func<Booking, bool>> filter = null)
        {
            return new SuccessDataResult<List<Booking>>(_bookingDal.GetAll(filter), Messages.Listed);
        }

        public IDataResult<BookingDetailDto> GetBookingDetail(Expression<Func<BookingDetailDto, bool>> filter)
        {
            return new SuccessDataResult<BookingDetailDto>(_bookingDal.GetBookingDetail(filter));
        }
    }
}
