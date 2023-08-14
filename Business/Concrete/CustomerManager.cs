using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            else
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
            }
            return new ErrorDataResult<List<Customer>>(Messages.NotFound);
        }

        public IDataResult<Customer> GetByBationalId(string nationalId)
        {
            var result = _customerDal.Get(c => c.NationalId == nationalId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.Listed);
            }

            return new ErrorDataResult<Customer>(Messages.NotFound);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.Listed);

            }
            return new ErrorDataResult<Customer>(Messages.NotFound);
        }

        public IDataResult<List<Customer>> GetByName(string name)
        {
            var result = _customerDal.GetAll(c => c.FirstName == name);//.Where(c => c.FirstName == name).ToList();
            if (result != null)
            {
                return new SuccessDataResult<List<Customer>>(result);
            }
            return new ErrorDataResult<List<Customer>>(Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
