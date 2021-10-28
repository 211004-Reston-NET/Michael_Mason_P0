using System;
using BL;
using Models;

namespace UI
{
    public class InventoryView : IMenu
    {
        private static string exceptionMessage;
        public static InventoryModel model;
        private static IInventoryBL _invBL;
        public InventoryView(IInventoryBL bl)
        {
            _invBL = bl;
        }
        public void Menu()
        {
            if (InventorySearch.PKey != 0)
            {
                model = _invBL.GetModel(InventorySearch.PKey);
                InventorySearch.PKey = 0;
            }
            if (InventoryList.PKey != 0)
            {
                model = _invBL.GetModel(InventoryList.PKey);
                InventoryList.PKey = 0;
            }

            Console.WriteLine("Inventory View");
            Console.WriteLine($"Inventory: {model.Id} | {model.Id}");
            Console.WriteLine("-------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify Name");
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
                            Console.WriteLine("Enter new Name");
                            model.Id = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.InventoryView;
                        }
                    return MenuType.InventoryUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.InventoryMenu;
            }
        }
    }
}