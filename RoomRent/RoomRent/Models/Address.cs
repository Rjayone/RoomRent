using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRent
{
    public class Address
    {
        public string Region { get; set; }
        public string Street { get; set; }
        public string HouseNumb { get; set; }
        public int FlatNumb { get; set; }


		override public string ToString()
		{
			return Region + ", " + Street + ", " + HouseNumb;
		}
	}
}
