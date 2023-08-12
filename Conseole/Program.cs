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

            

            var fonk = customerManager.Add(new Entities.Customer
            {
                eMail = "tuzunermetin@gmail.com",
                FirstName = "Metin",
                LastName = "Tüzüner",
                NationalId = "22222222222",
                PhoneNumber = "0544 444 44 44"
            });

            Console.WriteLine(fonk.Message);

        }
    }
}