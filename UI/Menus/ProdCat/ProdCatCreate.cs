using System;
using BL;
using Models;

namespace UI
{
    public class ProdCatCreate : IMenu
    {
        private static ProdCatModel model = new ProdCatModel();
        private static string exceptionMessage;
        private IProdCatBL _prodCatBL;
        public ProdCatCreate(IProdCatBL bl)
        {
            _prodCatBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a ProdCat");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Product ID: {model.ProdId}");
            Console.WriteLine($"Category ID: {model.CatId}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Product ID");
            Console.WriteLine("[2] Input Category ID");
            Console.WriteLine("[3] Save ProdCat");
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
                        Console.WriteLine("Enter Product ID");
                        model.ProdId = int.Parse(Console.ReadLine());
                        return MenuType.ProdCatCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProdCatCreate;
                    }
                case "2":
                    try
                    {
                        Console.WriteLine("Enter ProdCat Name");
                        model.CatId = int.Parse(Console.ReadLine());
                        return MenuType.ProdCatCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.ProdCatCreate;
                    }
                case "3":
                    try
                    {
                        _prodCatBL.CreateModel(model);
                        exceptionMessage = "ProdCat saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.ProdCatCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.ProdCatCreate;
            }
        }
    }
}