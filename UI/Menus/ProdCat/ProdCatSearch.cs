using System;
using System.Collections.Generic;
using System.Linq;
using BL;
using Models;

namespace UI
{
    public class ProdCatSearch : IMenu
    {
        private static string exceptionMessage;
        public static int PKey;
        private IProdCatBL _prodCatBL;
        public ProdCatSearch(IProdCatBL bl)
        {
            _prodCatBL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------------");
                exceptionMessage = null;
            }
            Console.WriteLine("Enter ProdCat Name");
            Console.WriteLine("-------------------");

            IEnumerable<ProdCatModel> items;

            string userInput = Console.ReadLine();
            if (userInput != "")
            {
                items = _prodCatBL.FindModel(userInput);

                Console.WriteLine("-------------------");

                if (items.Count() == 0)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    foreach (ProdCatModel item in items)
                    {
                        Console.WriteLine($"{item.Id} | {item.ProdId} | {item.CatId}");
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a search term");
            }



            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Search Again");
            Console.WriteLine("[2] View ProdCat");
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ProdCatMenu;
                case "1":
                    return MenuType.ProdCatSearch;
                case "2":
                    try
                    {
                        Console.WriteLine("Enter ProdCat Number");
                        string userInput = Console.ReadLine();
                        PKey = int.Parse(userInput);
                    }
                    catch (FormatException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProdCatSearch;
                    }
                    return MenuType.ProdCatView;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.ProdCatSearch;
            }
        }
    }
}