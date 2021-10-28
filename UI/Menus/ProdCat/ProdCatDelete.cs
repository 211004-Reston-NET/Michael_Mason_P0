using System;
using BL;

namespace UI
{
    public class ProdCatDelete : IMenu
    {
        private IProdCatBL _prodCatBL;
        public ProdCatDelete(IProdCatBL bl)
        {
            _prodCatBL = bl;
        }
        public void Menu(){}

        public MenuType UserSelection()
        {
            Console.WriteLine($"Are you sure you want to delete {ProdCatView.model}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodCatBL.DeleteModel(ProdCatView.model);
                    return MenuType.ProdCatList;
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