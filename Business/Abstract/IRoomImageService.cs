using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomImageService
    {
        IResult Add(RoomImage customer);
        public IResult Add2(IFormFile imageFile, int roomId);
        IResult Delete(RoomImage customer);
        IDataResult<RoomImage> Get(Expression<Func<RoomImage, bool>> filter);
        IDataResult<List<RoomImage>> GetAll(Expression<Func<RoomImage, bool>> filter = null);
    }
}
