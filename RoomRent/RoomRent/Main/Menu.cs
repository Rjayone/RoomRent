﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomRent.Common;
using RoomRent.Managers;
using RoomRent.Filter;

namespace RoomRent.MenuImplementation
{
	public class Menu
	{
		private XMLFileOperator dataSource;
		private List<Flat> flats;
		private List<string> regions;
		private RoomFilter filter;

		public Menu()
		{
			dataSource = new XMLFileOperator("file.xml");
			flats = dataSource.getAllFlatsFromXml();
			filter = new RoomFilter();
		}

		//Описание:
		//Метод выводит основное меню и считывает выбранный вариант
		public string printMainMenu()
		{
			Console.WriteLine("ULTIMATE FLAT FINDER 5000!");
			Console.WriteLine("1.  All flats");
			Console.WriteLine("2.  Add your flat");
			Console.WriteLine("3.  Search with filters");
			Console.WriteLine("0.  Exit");
			return Console.ReadLine();
		}

		//Описание:
		//Общий метод вывода списка квартир в консоль
		bool presentFlatsFromArray(List<Flat> flats)
		{
			Console.Clear();
			if (flats.Count == 0)
			{
				Console.WriteLine("Nothing founded");
				return false;
			}

			int i = 0;
			Console.WriteLine("-----------------------------------------------------------");
			for (i = 0; i < flats.Count; i++)
			{
				Flat flat = flats[i];
				Console.WriteLine(i + 1 + ". " + flat);
				Console.WriteLine("-----------------------------------------------------------");
			}
			return true;
		}

		//Описание:
		//Метод  выводит в консоль квартиры по заданному региону
		//Если ничего не найдено то возвращаемся в освновное меню, иначе пользователь может выбрать интересующую квартиру
		public void presentFlatsForRegionInArray(string region, List<Flat> flats)
		{
			Console.WriteLine("Please, select interesting postion");
			string index = Console.ReadLine();
			try
			{
				Flat flat = flats[Int16.Parse(index) - 1];
				printSelectedFlat(flat);
			}
			catch (Exception e)
			{
				Console.WriteLine("Incorrect index");
				return;
			}

		}


		public void printSelectedFlat(Flat flat)
		{
			Console.Clear();
			Console.WriteLine(flat);
			Console.WriteLine("Views count:" + dataSource.getViewsCountForFlatId(flat.Id));
			dataSource.updateViewsCountForFlatId(flat.Id);
			Console.WriteLine("1. Save to file");
			Console.WriteLine("2. Return to menu\n");
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
				if (regionIndex > regions.Count)
				{
					return "0";
				}
				
				string regionTitle = regions[regionIndex - 1];
				flats = dataSource.getAllFlatsFromXml();
				List<Flat> filteredFlats = filter.searchWithRegionInArray(regionTitle, flats);

				if (!presentFlatsFromArray(filteredFlats))
					return "0";
				
				presentFlatsForRegionInArray(regionTitle, filteredFlats);
			}
			else
			{
				Console.WriteLine("Incorrect index");
				return "0";
			}
			return "0";
		}


		//public void presentAddFlatPage()
		//{
		//	RoomsManager manager = new RoomsManager();
		//	manager.addRoom();
		//	Console.WriteLine("Your room was successfully added");
		//}

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
				if (!presentFlatsFromArray(filteredFlats))
					return;

				Console.WriteLine("Please, select interesting postion");
				string index = Console.ReadLine();
				try
				{
					Flat flat = flats[Int16.Parse(index) - 1];
					printSelectedFlat(flat);
				}
				catch
				{
					Console.WriteLine("Incorrect index");
				}
				
			} 
			else if( selection == "2")
			{
				Console.Clear();
				Console.Write("Enter price ");
				string price = Console.ReadLine();

				List<Flat> filteredFlats = filter.searchWithPriceInArray(price, flats);
				Console.Clear();
				if(!presentFlatsFromArray(filteredFlats))
					return;

				Console.WriteLine("Please, select interesting postion");
				string index = Console.ReadLine();
				try
				{
					Flat flat = flats[Int16.Parse(index)];
					printSelectedFlat(flat);
				}
				catch
				{
					Console.WriteLine("Incorrect index");
				}
			}
			else
			{
				Console.WriteLine("Incorrect index");
			}
		}
	}

	public static class MenuExtension
	{
		public static void presentAddFlatPage(this Menu menu)
		{
			RoomsManager manager = new RoomsManager();
			manager.addRoom();
			Console.WriteLine("Your room was successfully added");
		}
	}
}
