using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomRent
{
	class Program
	{
		static void Main(string[] args)
		{

            XMLFileOperator fileOperator = new XMLFileOperator("file.xml");
            Console.Write(fileOperator.getAllFlatsFromXml()[1].FlatAddress.FlatNumb);
            Console.Write(fileOperator.getAllRegions()[1]);
            Console.ReadKey();
            //fileOperator.CreateXmlFile();
            //Flat flat = new Flat();
            //flat.Id = 1;
            //flat.Price = 10;
            //flat.RoomCount = 3;

            //Address address = new Address();
            //address.Region = "serebro";
            //address.Street = "dfghj";
            //address.HouseNumb = "8";
            //address.FlatNumb = 5;

            //flat.FlatAddress = address;

            //fileOperator.FillFlatIntoXml(flat);
            //fileOperator.FillFlatIntoXml(flat);

		}
	}
}
