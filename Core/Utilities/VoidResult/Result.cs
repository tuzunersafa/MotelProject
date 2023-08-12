using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.VoidResult
{
    public class Result : IResult
    {
        public Result(string message, bool success) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            IsSuccess = success;
        }

        public string Message { get; }

        public bool IsSuccess { get; }
    }
}
