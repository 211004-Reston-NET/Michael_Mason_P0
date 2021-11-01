using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderView : IMenu
    {
        private static string exceptionMessage;
        public static SOrder sOrder;
        private static ISOrderBL BL;
        public SOrderView(ISOrderBL bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            if (SOrderSearch.orderId != 0)
            {
                sOrder = BL.GetById(SOrderSearch.orderId);
                SOrderSearch.orderId = 0;
            }
            if (SOrderList.orderId != 0)
            {
                sOrder = BL.GetById(SOrderList.orderId);
                SOrderList.orderId = 0;
            }

            Console.WriteLine("Order View");
            Console.WriteLine($"Order: {sOrder.OrderId} | {sOrder.TotalPrice}");
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
                            sOrder.OrderId = int.Parse(Console.ReadLine());
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