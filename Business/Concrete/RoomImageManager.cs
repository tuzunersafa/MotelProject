using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomImageManager : IRoomImageService
    {
        IRoomImageDal _roomImageDal;
        IImageHelper _imageHelper;
        public RoomImageManager(IRoomImageDal roomImageDal, IImageHelper imageHelper)
        {
            _roomImageDal = roomImageDal;
            _imageHelper = imageHelper;
        }


        public IResult Add(RoomImage roomImage)
        {
            _roomImageDal.Add(roomImage);
            return new SuccessResult();
        }

        public IResult Add2(IFormFile imageFile, int roomId)
        {
            var errorResult = BusinessRuleChecker.Check(
                CheckIfExtensionSupported(imageFile));

            if (!errorResult.IsSuccess)
            {
                return errorResult;
            }


            string imagePath = _imageHelper.SaveImageFileAndReturnFileName(imageFile).Data; //bu metot oluşturduğu dosya ismini döndürür

            var roomImage = new RoomImage
            {
                RoomId = roomId,
                FilePath = imagePath,
                UploadDate = DateTime.Now
            };

            _roomImageDal.Add(roomImage);
            return new SuccessResult();
        }

        

        public IResult Delete(RoomImage roomImage)
        {
            if (_imageHelper.Delete(roomImage.FilePath).IsSuccess)
            {
                _roomImageDal.Delete(roomImage);
                return new SuccessResult();
            }
            return new ErrorResult();
            
        }

        public IDataResult<RoomImage> Get(Expression<Func<RoomImage, bool>> filter)
        {
            var result = _roomImageDal.Get(filter);
            if (result != null)
            {
                return new SuccessDataResult<RoomImage>(result);
            }
            return new ErrorDataResult<RoomImage>(Messages.NotFound);
        }

        public IDataResult<List<RoomImage>> GetAll(Expression<Func<RoomImage, bool>> filter = null)
        {
            var result = _roomImageDal.GetAll(filter);
            if (result != null)
            {
                return new SuccessDataResult<List<RoomImage>>(result);
            }
            return new ErrorDataResult<List<RoomImage>>(Messages.NotFound);
        }





        private IResult CheckIfExtensionSupported(IFormFile imageFile)
        {
            var currentExtension = Path.GetExtension(imageFile.FileName);
            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (supportedExtensions.Contains(currentExtension))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.InvalidExtension);
        }
    }
}
