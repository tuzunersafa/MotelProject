using Core.DataAccess;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookingDal : IEntityRepository<Booking>
    {
        public BookingDetailDto GetBookingDetail(Expression<Func<BookingDetailDto, bool>> filter);
    }
}
