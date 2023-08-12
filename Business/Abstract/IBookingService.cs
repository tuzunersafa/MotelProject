using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookingService
    {
        IResult Add(Booking booking);
        IResult Update(Booking booking);
        IResult Delete(Booking booking);
        IDataResult<List<Booking>> GetAll();
        IDataResult<Booking> Get(int id);


        IResult CheckIn(Booking booking);
        IResult CheckOut(int bookingId, DateTime checkOutDate);

    }
}
