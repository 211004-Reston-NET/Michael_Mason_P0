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

            if (StorefrontView.storefront.StoreNumber == 0)
            {
                foreach (var item in BL.ListAllStores())
                {
                    Console.WriteLine($"[{item.StoreNumber}] | {item.StoreName}");
                }
                Console.WriteLine("-----");
                while (sOrder.StoreNumber <= 0)
                {
                    try
                    {
                        Console.WriteLine("Select store id");
                        sOrder.StoreNumber = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {

                sOrder.StoreNumber = StorefrontView.storefront.StoreNumber;
            }

            if (CustomerView.customer.CustNumber == 0)
            {
                while (!sOrder.CustNumber.HasValue)
                {
                    try
                    {
                        Console.WriteLine("Enter customer email");
                        var userInput = Console.ReadLine();
                        sOrder.CustNumber = BL.GetCustomerByEmail(userInput.ToLower()).CustNumber;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                sOrder.CustNumber = CustomerView.customer.CustNumber;
            }


            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Add line item");
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