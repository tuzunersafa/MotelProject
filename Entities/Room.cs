using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public int NumberOfBigBeds { get; set; }
        public int NumberOfSmallBeds { get; set; }
        public int NumberOfShower { get; set; }


    }
}
