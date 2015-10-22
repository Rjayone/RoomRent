using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRent.Managers
{
	class RoomsManager
	{
		public Flat addRoom()
		{
			Flat flat = new Flat();
			XMLFileOperator dataSource = new XMLFileOperator("file.xml");

			Console.Clear();
			Console.WriteLine("Add your room or apartament");
			Console.Write("1. Enter a region: ");
			flat.FlatAddress.Region = Console.ReadLine();
			Console.Write("Enter a street title: ");
			flat.FlatAddress.Street = Console.ReadLine();
			Console.Write("Enter a house number: ");
			flat.FlatAddress.HouseNumb = Console.ReadLine();
			Console.Write("Enter a flat number: ");
			flat.FlatAddress.FlatNumb = Int16.Parse(Console.ReadLine());
			Console.Write("Enter rooms count: ");
			flat.RoomCount = Int16.Parse(Console.ReadLine());
			Console.Write("Enter a monthly privce ");
			flat.Price = Int16.Parse(Console.ReadLine());

			dataSource.FillFlatIntoXml(flat);
			dataSource.fillCounter();

			return flat;
		}
	}
}
