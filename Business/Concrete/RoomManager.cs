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
            return new SuccessResult();
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



        IDataResult<List<Room>> IRoomService.GetAll()
        {
            var result = _roomDal.GetAll();
            return new SuccessDataResult<List<Room>>(result);
        }

        







        public IDataResult<List<Room>> GetByBigBedNumber(int number)
        {
            var result = _roomDal.GetAll().Where(r=> r.NumberOfBigBeds == number).ToList();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Room>>(result);
            }
            return new ErrorDataResult<List<Room>>(Messages.NotFound);
        }

        public IDataResult<Room> GetById(int id)
        {
            var result = _roomDal.Get(r=> r.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Room>(result,Messages.Listed);
            }
            return new ErrorDataResult<Room>(Messages.NotFound);
        }

        public IDataResult<List<Room>> GetByShowerNumber(int number)
        {
            var result = _roomDal.GetAll().Where(r => r.NumberOfShower == number).ToList();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Room>>(result);
            }
            return new ErrorDataResult<List<Room>>(Messages.NotFound);
        }

        public IDataResult<List<Room>> GetBySmallBedNumber(int number)
        {
            var result = _roomDal.GetAll().Where(r => r.NumberOfSmallBeds == number).ToList();
            if (result.Count() > 0)
            {
                return new SuccessDataResult<List<Room>>(result);
            }
            return new ErrorDataResult<List<Room>>(Messages.NotFound);
        }

        
    }
}
