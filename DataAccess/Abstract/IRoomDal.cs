using Core.DataAccess;
using Core.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoomDal : IEntityRepository<Room>
    {
    }
}
