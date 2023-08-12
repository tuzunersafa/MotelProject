using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }




        public IResult Add(Room room)
        {
            _roomDal.Add(room);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Room room)
        {
            _roomDal.Delete(room);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Room room)
        {
            _roomDal.Update(room);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Room>> GetByBigBedNumber(int number)
        {
            var result = _roomDal.GetAll().Where(r=> r.NumberOfBigBeds == number).ToList();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<Room>(result);
            }
        }

        public IDataResult<Room> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Room> GetByShowerNumber(int number)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Room> GetBySmallBedNumber(int number)
        {
            throw new NotImplementedException();
        }

        
    }
}
