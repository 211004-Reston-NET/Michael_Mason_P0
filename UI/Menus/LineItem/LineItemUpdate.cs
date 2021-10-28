using System;
using BL;

namespace UI
{
    public class LineItemUpdate : IMenu
    {
        private static string exceptionMessage;
        private ILineItemBL _lineBL;
        public LineItemUpdate(ILineItemBL bl)
        {
            _lineBL = bl;
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
            Console.WriteLine($"Are you sure you want to update {LineItemView.model.Id}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _lineBL.UpdateModel(LineItemView.model);
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