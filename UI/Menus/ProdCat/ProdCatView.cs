using System;
using BL;
using Models;

namespace UI
{
    public class ProdCatView : IMenu
    {
        private static string exceptionMessage;
        public static ProdCatModel model;
        private static IProdCatBL _prodCatBL;
        public ProdCatView(IProdCatBL bl)
        {
            _prodCatBL = bl;
        }
        public void Menu()
        {
            if (ProdCatSearch.PKey != 0)
            {
                model = _prodCatBL.GetModel(ProdCatSearch.PKey);
                ProdCatSearch.PKey = 0;
            }
            if (ProdCatList.PKey != 0)
            {
                model = _prodCatBL.GetModel(ProdCatList.PKey);
                ProdCatList.PKey = 0;
            }

            Console.WriteLine("ProdCat View");
            Console.WriteLine("-------------");
            var prodNameQuery = _prodCatBL.FindProductName(model.ProdId);
            Console.WriteLine($"Product ID: {prodNameQuery}");
            Console.WriteLine("Categories:");
            var fjcQuery = _prodCatBL.FindAndJoinCategories(model.Id);
            foreach (var item in fjcQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------");

            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Modify UPC");
            Console.WriteLine("[2] Modify Name");
            Console.WriteLine("[3] Modify Price");
            Console.WriteLine("[4] Modify Description");
            Console.WriteLine("[5] Save changes");
            Console.WriteLine("[6] Delete ProdCat");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ProdCatMenu;
                case "6":
                    return MenuType.ProdCatDelete;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.ProdCatMenu;
            }
        }
    }
}