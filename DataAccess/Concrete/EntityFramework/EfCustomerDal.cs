using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MotelContext>, ICustomerDal
    {

    }
}
