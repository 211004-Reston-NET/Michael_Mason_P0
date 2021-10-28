using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class SOrderList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private ISOrderBL _orderBL;
        public SOrderList(ISOrderBL bl)
        {
            _orderBL = bl;
        }

        public void Menu()
        {
            IEnumerable<SOrderModel> items = _orderBL.GetAllModel();

            Console.WriteLine("Order Listing");
            Console.WriteLine("----------------");
            foreach (SOrderModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.OrderNumber}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Orders Menu");
            Console.WriteLine("[1] Select SOrder");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.SOrderMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter Order ID");
                            string userInput = Console.ReadLine();
                            ProductCreate.catList.Add(int.Parse(userInput));
                            exceptionMessage = "Order added.";
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.SOrderList;
                        }
                    return MenuType.SOrderList;
                case "2":
                    return MenuType.ProductCreate;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.SOrderList;
            }
        }
    }
}