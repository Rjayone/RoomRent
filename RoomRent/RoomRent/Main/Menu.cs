using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomRent.Common;
using RoomRent.Managers;
using RoomRent.Filter;

namespace RoomRent.MenuImplementation
{
	class Menu
	{
		private XMLFileOperator dataSource;
		private List<Flat> flats;
		private List<string> regions;
		private RoomFilter filter;

		//Описание:
		//Метод выводит основное меню и считывает выбранный вариант
		public string printMainMenu()
		{
			if (dataSource == null)
				dataSource = new XMLFileOperator("file.xml");

			Console.WriteLine("ULTIMATE FLAT FINDER 5000!");
			Console.WriteLine("1.  All flats");
			Console.WriteLine("2.  Add your flat");
			Console.WriteLine("3.  Search with filters");
			Console.WriteLine("0.  Exit");
			return Console.ReadLine();
		}

		//Описание:
		//Общий метод вывода списка квартир в консоль
		void presentFlatsFromArray(List<Flat> flats)
		{
			if (flats.Count == 0)
			{
				Console.WriteLine("Nothing founded");
				return;
			}

			int i = 0;
			Console.WriteLine("-----------------------------------------------------------");
			for (i = 0; i < flats.Count; i++)
			{
				Flat flat = flats[i];
				Console.WriteLine(i + 1 + ". " + flat);
				Console.WriteLine("-----------------------------------------------------------");
			}
		}

		//Описание:
		//Метод  выводит в консоль квартиры по заданному региону
		//Если ничего не найдено то возвращаемся в освновное меню, иначе пользователь может выбрать интересующую квартиру
		public void presentFlatsForRegion(string region)
		{
			Console.Clear();
			flats = dataSource.getAllFlatsFromXml();
			if (filter == null)
				filter = new RoomFilter();

			List<Flat> filteredFlats = filter.searchWithRegionInArray(region, flats);
			presentFlatsFromArray(filteredFlats);
		}


		public void printSelectedFlat(List<Flat> flats)
		{
			if (flats.Count == 0)
				return;

			Console.WriteLine("Please, select interesting postion");
			string index = Console.ReadLine();
			Flat flat = flats[Int16.Parse(index)];

			Console.Clear();
			Console.WriteLine(flat);
			Console.WriteLine("1. Save to file");
			Console.WriteLine("2. Return to menu");
			string selection = Console.ReadLine();

			if (selection == "1")
				FileWriter.saveToFile(flat);
			else if (selection == "2")
				return;
		}

		//Описание:
		//Метод выводит доступные регионы на основе считанного хмл
		public string showRegions()
		{
			Console.Clear();
			Console.WriteLine("Available regions:");
			//Дописать получение всех регинов с дата сорса
			//Вывести в консоль доступные регионы
			//Сделать считывание с клавы и проверку, есть ли такой регион в списке
			//После возвращаем выбранный регион в presentFlatsForRegion(region);
			regions = dataSource.getAllRegions();
			int iterator = 1;
			foreach (string region in regions)
			{
				Console.WriteLine(iterator + ". " + region);
				iterator++;
			}

			Console.WriteLine("Please, enter the number of region");
			string selectedRegionIndex = Console.ReadLine();
			short regionIndex = 0;
			if (Int16.TryParse(selectedRegionIndex, out regionIndex))
			{
				string regionTitle = regions[regionIndex];
				presentFlatsForRegion(regionTitle);
			}
			else
			{
				Console.WriteLine("Something wrong");
				return "0";
			}
			return "0";
		}


		public void presentAddFlatPage()
		{
			RoomsManager manager = new RoomsManager();
			manager.addRoom();
			Console.WriteLine("Your room was successfully added");
		}

		public void presentFilters()
		{
			RoomFilter filter = new RoomFilter();
			Console.Clear();
			Console.WriteLine("1. Search for rooms count");
			Console.Write("2. Search for price\nYour choise ");
			string selection = Console.ReadLine();

			if (selection == "1")
			{
				Console.Clear();
				Console.Write("Enter rooms count ");
				string count = Console.ReadLine();

				List<Flat> filteredFlats = filter.searchWithRoomCountInArray(count, flats);
				Console.Clear();
				presentFlatsFromArray(filteredFlats);
			} 
			else if( selection == "2")
			{
				Console.Clear();
				Console.Write("Enter price ");
				string price = Console.ReadLine();

				List<Flat> filteredFlats = filter.searchWithPriceInArray(price, flats);
				Console.Clear();
				presentFlatsFromArray(filteredFlats);
			}
		}
	}
}
