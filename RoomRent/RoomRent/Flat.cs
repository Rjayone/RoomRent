using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRent
{
    public class Flat
    {
        
        public Address FlatAddress { get; set; }
        public int RoomCount { get; set;  }
        public int Price { get; set; }

        public long Id { get; set; }

    }
}
