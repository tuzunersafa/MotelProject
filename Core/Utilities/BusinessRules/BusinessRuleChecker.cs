using Core.Utilities.Result.VoidResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRules
{
    public static class BusinessRuleChecker
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    return new ErrorResult(logic.Message);
                }
            }
            return new SuccessResult();

        }
    }
}
