using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string eMail { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
    }
}
