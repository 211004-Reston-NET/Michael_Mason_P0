using System;
using Business;
using Data;
using System.Linq;

namespace UserInterface
{
    public class StorefrontOrderList : IMenu
    {
                private static string exceptionMessage;

        Storefront storefront;
        private static IStorefrontBL BL;
        public StorefrontOrderList(IStorefrontBL bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }

            Console.WriteLine("Orders\n-----\n");
            storefront = StorefrontView.storefront;
            var orders = BL.GetOrdersByStore(storefront);
            if (orders.Count() == 0)
            {
                Console.WriteLine("No orders yet");
            }
            else
            {
                foreach (var item in orders)
                {
                    var cust = BL.GetCustomerByOrder(item);
                    Console.WriteLine($"order #{item.OrderId} | customer id: {cust.CustName} | {cust.CustEmail} | total price: {item.TotalPrice}");
                }
            }
            Console.WriteLine("-----");
            Console.WriteLine("[0] Back");
        }

        public MenuType UserSelection()
        {
            var userSelection = Console.ReadLine();
            switch(userSelection)
            {
                case "0":
                    return MenuType.StorefrontView;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.StorefrontOrderList;
            }
        }
    }
}