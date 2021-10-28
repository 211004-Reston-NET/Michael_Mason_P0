using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class InventoryList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private IInventoryBL _invBL;
        public InventoryList(IInventoryBL bl)
        {
            _invBL = bl;
        }

        public void Menu()
        {
            IEnumerable<InventoryModel> items = _invBL.GetAllModel();

            Console.WriteLine("Inventory Listing");
            Console.WriteLine("----------------");
            foreach (InventoryModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.Id}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Inventory Menu");
            Console.WriteLine("[1] Select Inventory");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.InventoryMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter Inventory ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "Inventory added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.InventoryList;
                        }
                    return MenuType.InventoryList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventoryList;
            }
        }
    }
}