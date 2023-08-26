using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IImageHelper
    {
        public IDataResult<string> SaveImageFileAndReturnFileName(IFormFile imageFile);
        public IResult Delete(string imagePath);
    }
}
