using System;
using BL;

namespace UI
{
    public class ProdCatUpdate : IMenu
    {
        private static string exceptionMessage;
        private IProdCatBL _prodCatBL;
        public ProdCatUpdate(IProdCatBL bl)
        {
            _prodCatBL = bl;
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
            Console.WriteLine($"Are you sure you want to update {ProdCatView.model.Id}?");
            Console.WriteLine("[Y] or [N]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    _prodCatBL.UpdateModel(ProdCatView.model);
                    return MenuType.ProdCatList;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProdCatUpdate;      
            }
        }
    }
}