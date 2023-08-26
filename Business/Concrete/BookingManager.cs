using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.FluentValidation;
using Core.Utilities.BusinessRules;
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


        [ValidationAspect(typeof(BookingValidator))]
        public IResult Add(Booking booking)
        {
            //ValidationTool.Validate(new BookingValidator(), booking);

            _bookingDal.Add(booking);
            return new SuccessResult(Messages.Added);
        }

        public IResult CheckIn(Booking booking)
        {

            var errorResults = BusinessRuleChecker.Check(CheckIfRoomIsEmpty(booking.RoomId));

            if (errorResults.IsSuccess)
            {
                _bookingDal.Add(booking);
                return new SuccessResult(Messages.CheckedIn);
            }

            return new ErrorResult(Messages.RoomInUse);
        }

        public IResult CheckOut(int bookingId, DateTime checkOutDate)
        {
            var errorResults = BusinessRuleChecker.Check(CheckIfRoomInUse(bookingId));

            if (errorResults.IsSuccess)
            {
                var booking = _bookingDal.Get(b=> b.Id == bookingId);
                booking.CheckOutDate = checkOutDate;
                _bookingDal.Update(booking);
                return new SuccessResult(Messages.CheckedOut);

            }
            return new ErrorResult(errorResults.Message);


            
            

            

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

        //public virtual IDataResult<List<Booking>> GetByCheckInDate(DateTime minDate, DateTime maxDate)
        //{
        //    var result = _bookingDal.GetAll(b => b.CheckInDate > minDate && b.CheckInDate < maxDate).ToList();
        //    if (result != null)
        //    {
        //        return new SuccessDataResult<List<Booking>>(result, Messages.Listed);
        //    }
        //    else return new ErrorDataResult<List<Booking>>();
        //}




        //RULES

        private IResult CheckIfRoomIsEmpty(int roomId)
        {
            var result = _bookingDal.GetBookingDetail(b=> b.RoomId == roomId);
            if (result!= null)
            {
                return new ErrorResult(Messages.RoomInUse);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRoomInUse(int bookingId)
        {
            var result = _bookingDal.GetBookingDetail(b => b.Id == bookingId);
            if (result == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
