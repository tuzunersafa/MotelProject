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

            //bookingManager.Add(new Entities.Booking { CustomerId= 1, RoomId= 1 ,CheckInDate = new DateTime(2023,12,31)});

            
            //Console.WriteLine(bookingManager.CheckOut(1, new DateTime(2023, 12, 31)).Message);


            //var fonk = customerManager.Update(new Entities.Customer
            //{
            //    Id = 2,
            //    FirstName = "Ayşe",
            //    LastName = "Tüzüner",
            //    NationalId = "5156123111",
            //    PhoneNumber = "543 333 33 33",
            //});

            //Console.WriteLine(fonk.Message);



            //Console.WriteLine(customerManager.GetById(1).Data.FirstName);

            //foreach (var customer in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(customer.FirstName);
            //}


            var bookingDal = new EfBookingDal();

            var results = bookingDal.GetAll(b=> b.CheckInDate < DateTime.Today && b.CheckInDate> DateTime.Now.AddYears(-5));

            foreach (var item in results)
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}