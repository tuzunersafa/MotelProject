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
    public class ImageHelper : IImageHelper
    {
        public IResult Delete(string imagePath)
        {
            File.Delete(Path.Combine("wwwroot/images",imagePath));
            return new SuccessResult();

        }

        public IDataResult<string> SaveImageFileAndReturnFileName(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return new ErrorDataResult<string>(null, $"{imageFile.FileName} bulunamadı");
            }

            Guid guid = Guid.NewGuid();
            string fileExtension = Path.GetExtension(imageFile.FileName);

            string fileName = $"{guid}{fileExtension}";
            string filePath = Path.Combine("wwwroot/images",fileName);

            using (var fileStream = new FileStream(filePath,FileMode.Create) )
            {
                imageFile.CopyTo(fileStream);
            }

            var toReturn = new SuccessDataResult<string>(fileName,"Görsel klasöre kaydedildi");
            return toReturn;
        }
    }
}
