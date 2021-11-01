using System;
using Business;

namespace UserInterface
{
    public class LineItemUpdate : IMenu
    {
        private static string exceptionMessage;
        private ILineItemBL BL;
        public LineItemUpdate(ILineItemBL bl)
        {
            BL = bl;
        }

        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------------");
                exceptionMessage = null;
            }
            // Console.WriteLine($"Are you sure you want to update {LineItemView.lineItem.Id}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Update(LineItemView.lineItem);
                    return MenuType.LineItemList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.LineItemUpdate;      
            }
        }
    }
}