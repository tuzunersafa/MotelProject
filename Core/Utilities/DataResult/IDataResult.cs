using Core.Utilities.VoidResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.DataResult
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
