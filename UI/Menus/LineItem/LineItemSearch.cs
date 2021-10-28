using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class LineItemSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private ILineItemBL _lineBL;
        public LineItemSearch(ILineItemBL bl)
        {
            _lineBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter LineItem Name");
            Console.WriteLine("-------------------");

            IEnumerable<LineItemModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _lineBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (LineItemModel item in items)
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
            Console.WriteLine("[2] View LineItem");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.LineItemMenu;
                case "1":
                    return MenuType.LineItemSearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter LineItem Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.LineItemSearch;
                    }
                    return MenuType.LineItemView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.LineItemSearch;
            }
        }
    }
}