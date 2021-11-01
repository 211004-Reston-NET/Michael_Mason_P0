using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class InventoryCreate : IMenu
    {
        private static Inventory inventory;
        private static string exceptionMessage;
        private IInventoryBl BL;
        public InventoryCreate(IInventoryBl bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            inventory = new Inventory();
            inventory.Prod = new Product();
            Console.WriteLine("Add a Product");
            Console.WriteLine("-----");
            Console.WriteLine("Product name");
            inventory.Prod.ProdName = Console.ReadLine();
            Console.WriteLine("Product price");
            inventory.Prod.ProdPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Product Description");
            inventory.Prod.ProdDescription = Console.ReadLine();
            Console.WriteLine("Product category");
            inventory.Prod.ProdCategory = Console.ReadLine();
            Console.WriteLine("-----");
            Console.WriteLine("Store number");
            inventory.StoreNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantity");
            inventory.Quantity = int.Parse(Console.ReadLine());
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
            Console.WriteLine("-----");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save Inventory");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.InventoryMenu;
                case "1":
                    try
                    {
                        return MenuType.InventoryList;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.InventoryCreate;
                    }
                case "2":
                    try
                    {
                        Console.WriteLine(BL.Create(inventory));
                        BL.Save();
                        return MenuType.InventoryList;
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                                            return MenuType.InventoryCreate;

                    }
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.InventoryCreate;
            }
        }
    }
}