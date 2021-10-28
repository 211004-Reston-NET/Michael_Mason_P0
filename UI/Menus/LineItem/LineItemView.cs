using System;
using BL;
using Models;

namespace UI
{
    public class LineItemView : IMenu
    {
        private static string exceptionMessage;
        public static LineItemModel model;
        private static ILineItemBL _lineBL;
        public LineItemView(ILineItemBL bl)
        {
            _lineBL = bl;
        }
        public void Menu()
        {
            if (LineItemSearch.PKey != 0)
            {
                model = _lineBL.GetModel(LineItemSearch.PKey);
                LineItemSearch.PKey = 0;
            }
            if (LineItemList.PKey != 0)
            {
                model = _lineBL.GetModel(LineItemList.PKey);
                LineItemList.PKey = 0;
            }

            Console.WriteLine("LineItem View");
            Console.WriteLine($"LineItem: {model.Id} | {model.Id}");
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
                            Console.WriteLine("Enter new Name");
                            model.Id = int.Parse(Console.ReadLine());
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