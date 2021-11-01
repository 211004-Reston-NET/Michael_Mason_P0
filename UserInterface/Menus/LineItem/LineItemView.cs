using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class LineItemView : IMenu
    {
        private static string exceptionMessage;
        public static LineItem lineItem;
        private static ILineItemBL BL;
        public LineItemView(ILineItemBL bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            // if (LineItemSearch.PKey != 0)
            // {
            //     lineItem = BL.GetById(LineItemSearch.PKey);
            //     LineItemSearch.PKey = 0;
            // }
            // if (LineItemList.PKey != 0)
            // {
            //     lineItem = BL.GetModel(LineItemList.PKey);
            //     LineItemList.PKey = 0;
            // }

            Console.WriteLine("Line Item View");
            // Console.WriteLine($"LineItem: {lineItem.Id} | {lineItem.Id}");
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
                    return MenuType.LineItemMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter new ID");
                            // lineItem.Id = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.LineItemView;
                        }
                    return MenuType.LineItemUpdate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.LineItemMenu;
            }
        }
    }
}