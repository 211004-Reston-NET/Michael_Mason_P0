using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderList : IMenu
    {
        private static string exceptionMessage;
        public static int orderId;

        private ISOrderBL BL;
        public SOrderList(ISOrderBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            IEnumerable<SOrder> items = BL.GetAll();

            Console.WriteLine("Order Listing");
            Console.WriteLine("----------------");
            foreach (var item in items)
            {
                var cust = BL.GetCustomerById((int)item.CustNumber);
                var store = BL.GetStorefrontById((int)item.StoreNumber);
                Console.WriteLine($"{item.OrderId} | {store.StoreName} | {cust.CustName} | {item.TotalPrice}");
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