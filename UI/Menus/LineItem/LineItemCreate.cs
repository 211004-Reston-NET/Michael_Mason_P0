using System;
using BL;
using Models;

namespace UI
{
    public class LineItemCreate : IMenu
    {
        private static LineItemModel newModel = new LineItemModel();
        private static string exceptionMessage;
        private ILineItemBL _lineBL;
        public LineItemCreate(ILineItemBL bl)
        {
            _lineBL = bl;
        }

        public void Menu()
        {
            Console.WriteLine("Create a LineItem");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Name: {newModel.Id}");
            Console.WriteLine("-----------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Input Name");
            Console.WriteLine("[2] Save LineItem");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.LineItemMenu;
                case "1":
                    try
                    {
                        Console.WriteLine("Enter the LineItem ID");
                        newModel.Id = int.Parse(Console.ReadLine());
                        return MenuType.LineItemCreate;
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.LineItemCreate;
                    }
                case "2":
                    try
                    {
                        _lineBL.CreateModel(newModel);
                        exceptionMessage = "LineItem saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.LineItemCreate;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.LineItemCreate;
            }
        }
    }
}