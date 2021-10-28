using System;
using BL;
using Models;

namespace UI
{
    public class InventoryCreate : IMenu
    {
        private static InventoryModel newModel = new InventoryModel();
        private static string exceptionMessage;
        private IInventoryBL _invBL;
        public InventoryCreate(IInventoryBL bl)
        {
            _invBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a Inventory");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.Id}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
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
                        Console.WriteLine("Enter the Inventory Name");
                        newModel.Id = int.Parse(Console.ReadLine());
                        return MenuType.InventoryCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.InventoryCreate;
                    }
                case "2":
                    try
                    {
                        _invBL.CreateModel(newModel);
                        exceptionMessage = "Inventory saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.InventoryCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.InventoryCreate;
            }
        }
    }
}