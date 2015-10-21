using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RoomRent.Common
{
	class FileWriter
	{
		public static bool saveToFile(object obj)
		{ 
			//object можно заменить на конкретный тип
			//Метод должен производить запись в файл принятого объекта
			string fileName = "";
			Console.Clear();
			Console.WriteLine("Please, print name of file to save(without extension)");
			fileName = Console.ReadLine();
			File.WriteAllText(fileName + ".txt", obj.ToString(), Encoding.Unicode);
			return true;
		}
	}
}
