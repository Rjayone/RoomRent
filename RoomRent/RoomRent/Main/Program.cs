using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomRent.MenuImplementation;

namespace RoomRent
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu menu = new Menu();
			String selection = "";			
			while (selection != "0")
			{
				selection = menu.printMainMenu();
				if (selection == "1")
					menu.showRegions();
				else if (selection == "2")
					menu.presentAddFlatPage();
				else if (selection == "3")
					menu.presentFilters();
				Console.Clear();
			}

		}
	}
}
