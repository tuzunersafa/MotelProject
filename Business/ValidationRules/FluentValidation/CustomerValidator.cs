using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c=> c.FirstName).NotEmpty();
            RuleFor(c => c.NationalId).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();



        }
    }
}
