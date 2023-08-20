using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
        IResult Add(Room room);
        
        IResult Update(Room room);
        IResult Delete(Room room);
        IDataResult<Room> GetById(int id);
        IDataResult<List<Room>> GetAll();
        IDataResult<List<Room>> GetBySmallBedNumber(int number);
        IDataResult<List<Room>> GetByShowerNumber(int number);
        IDataResult<List<Room>> GetByBigBedNumber(int number);
        
    }
}
