using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookingService
    {
        IResult Add(Booking booking);
        IResult Update(Booking booking);
        IResult Delete(Booking booking);
        IDataResult<List<Booking>> GetAll(Expression<Func<Booking, bool>> filter = null);
        IDataResult<Booking> Get(Expression<Func<Booking, bool>> filter);

        IDataResult<BookingDetailDto> GetBookingDetail(Expression<Func<BookingDetailDto, bool>> filter);
        IResult CheckIn(Booking booking);
        IResult CheckOut(int bookingId, DateTime checkOutDate);

    }
}
