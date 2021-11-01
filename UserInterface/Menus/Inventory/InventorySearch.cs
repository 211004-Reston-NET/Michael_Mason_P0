using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class InventorySearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private IInventoryBl BL;
        public InventorySearch(IInventoryBl bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Store Name");
            Console.WriteLine("-------------------");


            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                
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