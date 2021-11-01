using System;
using Business;

namespace UserInterface
{
    public class LineItemDelete : IMenu
    {
        private ILineItemBL BL;
        public LineItemDelete(ILineItemBL bl)
        {
            BL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {LineItemView.lineItem}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    BL.Delete(LineItemView.lineItem);
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