using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookingDal : EfEntityRepositoryBase<Booking, MotelContext>, IBookingDal
    {
        public BookingDetailDto GetBookingDetail(Expression<Func<BookingDetailDto, bool>> filter)
        {
            using (MotelContext context = new MotelContext())
            {
                var result = from b in context.Bookings join c in context.Customers on b.CustomerId equals c.Id select new BookingDetailDto { CheckInDate = b.CheckInDate, CheckOutDate = b.CheckOutDate, Id = b.Id, CustomerId = c.Id, CustomerFirstName = c.FirstName };
                return result.SingleOrDefault(filter);
            }
            
        }
    }
}
