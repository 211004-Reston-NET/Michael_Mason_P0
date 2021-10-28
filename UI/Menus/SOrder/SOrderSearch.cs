using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class SOrderSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private ISOrderBL _orderBL;
        public SOrderSearch(ISOrderBL bl)
        {
            _orderBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter Order Number");
            Console.WriteLine("-------------------");

            IEnumerable<SOrderModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _orderBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (SOrderModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.OrderNumber}");
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
            Console.WriteLine("[2] View SOrder");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.SOrderMenu;
                case "1":
                    return MenuType.SOrderSearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter Order Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.SOrderSearch;
                    }
                    return MenuType.SOrderView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.SOrderSearch;
            }
        }
    }
}