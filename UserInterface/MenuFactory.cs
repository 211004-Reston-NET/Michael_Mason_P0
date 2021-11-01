using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Business;
using Data;

namespace UserInterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType menu)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration

            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                .Options;

            switch (menu)
            {
                // DEFAULT
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.ExitMenu:
                    return new ExitMenu();
                
                // PRODUCT


                // STOREFRONT
                case MenuType.StorefrontMenu:
                    return new StorefrontMenu();
                case MenuType.StorefrontCreate:
                    return new StorefrontCreate(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));
                case MenuType.StorefrontList:
                    return new StorefrontList(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));
                case MenuType.StorefrontSearch:
                    return new StorefrontSearch(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));
                case MenuType.StorefrontView:
                    return new StorefrontView(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));

                //CUSTOMER
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.CustomerCreate:
                    return new CustomerCreate(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));
                case MenuType.CustomerList:
                    return new CustomerList(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));
                case MenuType.CustomerSearch:
                    return new CustomerSearch(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));
                case MenuType.CustomerView:
                    return new CustomerView(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));

                // SOrder
                case MenuType.SOrderMenu:
                    return new SOrderMenu();
                case MenuType.SOrderCreate:
                    return new SOrderCreate(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderView:
                    return new SOrderView(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));

                // LINEITEM
                case MenuType.LineItemCreate:
                    return new LineItemCreate(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));

                // Inventory
                case MenuType.InventoryCreate:
                    return new InventoryCreate(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));

                default:
                    return new MainMenu();
            }
        }
    }
}