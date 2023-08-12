using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetByName(string name);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByBationalId(string nationalId);


    }
}
