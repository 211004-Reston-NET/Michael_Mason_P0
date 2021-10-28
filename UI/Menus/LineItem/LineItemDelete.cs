using System;
using BL;

namespace UI
{
    public class LineItemDelete : IMenu
    {
        private ILineItemBL _lineBL;
        public LineItemDelete(ILineItemBL bl)
        {
            _lineBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {LineItemView.model}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _lineBL.DeleteModel(LineItemView.model);
                    return MenuType.LineItemList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ExitMenu;      
            }
        }
    }
}