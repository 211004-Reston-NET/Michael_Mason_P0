using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class LineItemSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private ILineItemBL BL;
        public LineItemSearch(ILineItemBL bl)
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
            Console.WriteLine("Enter Line Item Name");
            Console.WriteLine("-------------------");

            IEnumerable<LineItem> items;

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
            Console.WriteLine("[2] View Line Item");
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
                        Console.WriteLine("Enter Line Item Number");
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