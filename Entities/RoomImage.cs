using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoomImage : IEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }

        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        
    }
}
