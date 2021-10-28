using System;
using System.Collections.Generic;
using BL;
using Models;

namespace UI
{
    public class ProdCatList : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;

        private IProdCatBL _prodCatBL;
        public ProdCatList(IProdCatBL bl)
        {
            _prodCatBL = bl;
        }

        public void Menu()
        {
            IEnumerable<ProdCatModel> items = _prodCatBL.GetAllModel();

            Console.WriteLine("ProdCat Listing");
            Console.WriteLine("----------------");
            foreach (ProdCatModel item in items)
            {
                Console.WriteLine($"{item.Id} | {item.ProdId} | {item.CatId}");
            }
            Console.WriteLine("----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Categories Menu");
            Console.WriteLine("[1] Select ProdCat");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ProdCatMenu;
                case "1":
                        try
                        {
                            Console.WriteLine("Enter ProdCat ID");
                            string userInput = Console.ReadLine();
                            PKey = int.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            exceptionMessage = "You must enter an ID";
                            return MenuType.ProdCatList;
                        }
                    return MenuType.ProdCatView;

                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProdCatList;
            }
        }
    }
}