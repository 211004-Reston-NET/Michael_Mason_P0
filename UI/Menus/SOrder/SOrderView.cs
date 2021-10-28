using System;
using BL;
using Models;

namespace UI
{
    public class SOrderView : IMenu
    {
        private static string exceptionMessage;
        public static SOrderModel model;
        private static ISOrderBL _orderBL;
        public SOrderView(ISOrderBL bl)
        {
            _orderBL = bl;
        }
        public void Menu()
        {
            if (SOrderSearch.PKey != 0)
            {
                model = _orderBL.GetModel(SOrderSearch.PKey);
                SOrderSearch.PKey = 0;
            }
            if (SOrderList.PKey != 0)
            {
                model = _orderBL.GetModel(SOrderList.PKey);
                SOrderList.PKey = 0;
            }

            Console.WriteLine("Order View");
            Console.WriteLine($"Order: {model.Id} | {model.OrderNumber}");
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
                    return MenuType.SOrderMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter new Name");
                            model.OrderNumber = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.SOrderView;
                        }
                    return MenuType.SOrderUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.SOrderMenu;
            }
        }
    }
}