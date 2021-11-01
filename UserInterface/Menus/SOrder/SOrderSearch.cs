using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderSearch : IMenu
    {
        private static string exceptionMessage;
        public static int orderId;
        private ISOrderBL BL;
        public SOrderSearch(ISOrderBL bl)
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
            Console.WriteLine("Enter Order Number");
            Console.WriteLine("-------------------");

            IEnumerable<SOrder> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                // items = BL.GetById(int.Parse(userInput));

                // Console.WriteLine("-------------------");

                // if (items.Count() == 0)
                // {
                //     Console.WriteLine("Not found");
                // }
                // else
                // {
                //     foreach (var item in items)
                //     {
                //         Console.WriteLine($"{item.Id} | {item.OrderNumber}");
                //     }
                // }
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
                        orderId = int.Parse(userInput);
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