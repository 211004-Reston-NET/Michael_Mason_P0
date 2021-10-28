using System;
using BL;
using Models;

namespace UI
{
    public class SOrderCreate : IMenu
    {
        private static SOrderModel newModel = new SOrderModel();
        private static string exceptionMessage;
        private ISOrderBL _orderBL;
        public SOrderCreate(ISOrderBL bl)
        {
            _orderBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a SOrder");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.OrderNumber}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save SOrder");
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
                        Console.WriteLine("Enter the SOrder Name");
                        newModel.OrderNumber = int.Parse(Console.ReadLine());
                        return MenuType.SOrderCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.SOrderCreate;
                    }
                case "2":
                    try
                    {
                        _orderBL.CreateModel(newModel);
                        exceptionMessage = "SOrder saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.SOrderCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.SOrderCreate;
            }
        }
    }
}