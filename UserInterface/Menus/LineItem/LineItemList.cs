using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class LineItemList : IMenu
    {
        private static string exceptionMessage;

        private ILineItemBL BL;
        public LineItemList(ILineItemBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            IEnumerable<LineItem> items = BL.GetAll();

            Console.WriteLine("LineItem Listing");
            Console.WriteLine("----------------");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.OrderId} | {item.ProdId}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Line Items Menu");
            Console.WriteLine("[1] Select LineItem");
            Console.WriteLine("[2] Back to ---");
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