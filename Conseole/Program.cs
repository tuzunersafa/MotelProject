using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Conseole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            IBookingService bookingManager = new BookingManager(new  EfBookingDal());   

         

            var bookingDal = new EfBookingDal();

            var results = bookingDal.GetAll(b=> b.CheckInDate < DateTime.Today && b.CheckInDate> DateTime.Now.AddYears(-5));

            foreach (var item in results)
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}