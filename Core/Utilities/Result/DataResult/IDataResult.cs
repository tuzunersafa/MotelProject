using Core.Utilities.Result.VoidResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result.DataResult
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
