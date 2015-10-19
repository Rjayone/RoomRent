using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRent.Filter
{
	class RoomFilter
	{
		public List<Flat> searchWithRegionInArray(string region, List<Flat> flats)
		{
			List<Flat> filteredFlats = new List<Flat>();
			foreach (Flat flat in flats)
			{
				if (flat.FlatAddress.Region == region)
					filteredFlats.Add(flat);
			}
			return filteredFlats;
		}

		public List<Flat> searchWithRoomCountInArray(string count, List<Flat> flats)
		{
			List<Flat> filteredFlats = new List<Flat>();
			foreach (Flat flat in flats)
			{
				if (flat.RoomCount == Int16.Parse(count))
					filteredFlats.Add(flat);
			}
			return filteredFlats;
		}

		public List<Flat> searchWithPriceInArray(string price, List<Flat> flats)
		{
			List<Flat> filteredFlats = new List<Flat>();
			foreach (Flat flat in flats)
			{
				if (flat.Price <= Int16.Parse(price))
					filteredFlats.Add(flat);
			}
			return filteredFlats;
		}
	}
}
