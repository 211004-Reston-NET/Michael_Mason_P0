using System;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class LineItemCreate : IMenu
    {
        LineItem lineItem;
        private static string exceptionMessage;
        private ILineItemBL BL;
        public LineItemCreate(ILineItemBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            lineItem = new LineItem();
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }

            lineItem.OrderId = SOrderCreate.sOrder.OrderId;

            var items = BL.ListAllProducts((int)SOrderCreate.sOrder.StoreNumber);
            if (items.Count() == 0)
            {
                Console.WriteLine("This store has no items for sale");
                Console.WriteLine("[0] Back");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"[{item.ProdId}] | {item.ProdName} | {item.ProdPrice}");
                }
                Console.WriteLine("-----");

                while (!lineItem.ProdId.HasValue)
                {
                    try
                    {
                        Console.WriteLine("Enter product id");
                        lineItem.ProdId = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                while (lineItem.Quantity <= 0)
                {
                    try
                    {
                        Console.WriteLine("Enter quantity");
                        var quantity = int.Parse(Console.ReadLine());
                        var check = BL.CheckInventory((int)SOrderCreate.sOrder.StoreNumber, (int)lineItem.ProdId, lineItem.Quantity);
                        // while loop?
                        if (quantity < check)
                        {
                            lineItem.Quantity = quantity;
                        }
                        else
                        {
                            Console.WriteLine("Not enough stock");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }



                Console.WriteLine("-----");
                Console.WriteLine("[0] Back");
                Console.WriteLine("[1] Save line item");
            }

        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    BL.DeleteOrder(SOrderCreate.sOrder);
                    BL.Save();
                    return MenuType.LineItemMenu;
                case "1":
                    try
                    {
                        BL.Create(lineItem);
                        BL.Save();
                        exceptionMessage = "Line item created";
                        Console.WriteLine("Enter another item? [y]/[n]");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            return MenuType.LineItemCreate;
                        }
                        else
                        {
                            BL.UpdateInventory(SOrderCreate.sOrder);
                            BL.UpdateTotalPrice(SOrderCreate.sOrder);
                            BL.Save();
                            return MenuType.SOrderView;
                        }
                    }
                    catch (Exception e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.LineItemCreate;
                    }
                case "2":
                    try
                    {
                        exceptionMessage = BL.Save();
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    SOrderCreate.sOrder = null;
                    return MenuType.LineItemMenu;
                default:
                    exceptionMessage = ".....INVALID SELECTION...";
                    return MenuType.LineItemCreate;
            }
        }
    }
}