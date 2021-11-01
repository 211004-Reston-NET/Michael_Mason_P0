using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderCreate : IMenu
    {
        public static SOrder sOrder;
        private static string exceptionMessage;
        private ISOrderBL BL;
        public SOrderCreate(ISOrderBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Create an Order");
            Console.WriteLine("-----");
            sOrder = new SOrder();
            foreach (var item in BL.ListAllStores())
            {
                Console.WriteLine($"[{item.StoreNumber}] | {item.StoreName}");
            }
            Console.WriteLine("-----");
            Console.WriteLine("Select store id");
            sOrder.StoreNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter customer email");
            sOrder.CustNumber = BL.GetCustomerByEmail(Console.ReadLine().ToLower()).CustNumber;

            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[2] Add line item");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.SOrderMenu;
                
                case "2":
                    try
                    {
                        BL.Create(sOrder);
                        BL.Save();
                        exceptionMessage = "Order saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.LineItemCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.SOrderCreate;
            }
        }
    }
}