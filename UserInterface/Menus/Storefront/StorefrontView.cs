using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontView : IMenu
    {
        private static string exceptionMessage;
        public static Storefront storefront;
        public static List<Inventory> inventory;
        private static IStorefrontBL BL;
        public StorefrontView(IStorefrontBL bl)
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

            if (StorefrontSearch.storefront != null)
            {
                storefront = StorefrontSearch.storefront;
                StorefrontSearch.storefront = null;
            }
            if (StorefrontList.storefront != null)
            {
                storefront = StorefrontList.storefront;
                StorefrontList.storefront = null;
            }

            Console.WriteLine("Storefront View");
            Console.WriteLine($"Storefront: {storefront.StoreName} | {storefront.StoreAddress}");
            Console.WriteLine("-----");
            Console.WriteLine("Inventory");
            Console.WriteLine("[id] | Product Name | Quantity");
            inventory = BL.GetInventoryByStore(storefront.StoreNumber).ToList();
            foreach (var item in inventory)
            {
                Console.WriteLine($"[{item.InvId}] | {BL.GetProductByProdId((int)item.ProdId).ProdName} | {item.Quantity}");
            }
            Console.WriteLine("-----");

            var orders = BL.GetOrdersByStore(storefront);
            foreach (var item in orders)
            {
                var cust = BL.GetCustomerByOrder(item);
                Console.WriteLine($"order #{item.OrderId} | customer id: {cust.CustName} | {cust.CustEmail} | total price: {item.TotalPrice}");
            }
            Console.WriteLine("-----");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Update inventory");
            Console.WriteLine("[2] Begin order");
        }


        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontMenu;
                case "1":
                    Console.WriteLine("Enter product id");
                    var invId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new quantity");
                    Console.WriteLine(BL.UpdateInventory(invId, int.Parse(Console.ReadLine())));
                    return MenuType.StorefrontView;
                case "2":
                    return MenuType.SOrderCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.StorefrontMenu;
            }
        }
    }
}