using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class LineItemList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private ILineItemBL _lineBL;
        public LineItemList(ILineItemBL bl)
        {
            _lineBL = bl;
        }

        public void Menu()
        {
            IEnumerable<LineItemModel> items = _lineBL.GetAllModel();

            Console.WriteLine("LineItem Listing");
            Console.WriteLine("----------------");
            foreach (LineItemModel item in items)
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
            Console.WriteLine("[0] Back to Categories Menu");
            Console.WriteLine("[1] Select LineItem");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.LineItemMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter LineItem ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "LineItem added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.LineItemList;
                        }
                    return MenuType.LineItemList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.LineItemList;
            }
        }
    }
}