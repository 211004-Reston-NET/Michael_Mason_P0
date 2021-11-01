using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class InventoryList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private IInventoryBl BL;

        IEnumerable<Inventory> items;
        public InventoryList(IInventoryBl bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            items = BL.GetAll();

            Console.WriteLine("Inventory Listing");
            Console.WriteLine("----------------");
            foreach (var item in items)
            {
                var store = BL.GetStorefrontByStoreId((int)item.StoreNumber);
                var product = BL.GetProductByProdId((int)item.ProdId);
                Console.WriteLine($"[{item.InvId}] {store.StoreName} . {product.ProdName} . {item.Quantity}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Inventory Menu");
            Console.WriteLine("[1] Select Inventory");
            Console.WriteLine("[2] Back to Product");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.InventoryMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.InventoryList;
            }
        }
    }
}