using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class InventorySearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private IInventoryBL _invBL;
        public InventorySearch(IInventoryBL bl)
        {
            _invBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Inventory Name");
            Console.WriteLine("-------------------");

            IEnumerable<InventoryModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _invBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (InventoryModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.Id}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a search term");
            }



            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search Again");
            Console.WriteLine("[2] View Inventory");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.InventoryMenu;
                case "1":
                    return MenuType.InventorySearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Inventory Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.InventorySearch;
                    }
                    return MenuType.InventoryView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventorySearch;
            }
        }
    }
}