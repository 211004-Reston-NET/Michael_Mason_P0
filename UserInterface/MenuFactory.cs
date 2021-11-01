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
                case MenuType.ProductMenu:
                    return new ProductMenu();
                case MenuType.ProductCreate:
                    return new ProductCreate(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));
                case MenuType.ProductList:
                    return new ProductList(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));
                case MenuType.ProductSearch:
                    return new ProductSearch(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));
                case MenuType.ProductView:
                    return new ProductView(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));
                case MenuType.ProductUpdate:
                    return new ProductUpdate(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));
                case MenuType.ProductDelete:
                    return new ProductDelete(new ProductBL(new Repository<Product>(new StoreManagerContext(options))));

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
                case MenuType.StorefrontUpdate:
                    return new StorefrontUpdate(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));
                case MenuType.StorefrontDelete:
                    return new StorefrontDelete(new StorefrontBL(new Repository<Storefront>(new StoreManagerContext(options))));

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
                case MenuType.CustomerUpdate:
                    return new CustomerUpdate(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));
                case MenuType.CustomerDelete:
                    return new CustomerDelete(new CustomerBL(new Repository<Customer>(new StoreManagerContext(options))));

                // SOrder
                case MenuType.SOrderMenu:
                    return new SOrderMenu();
                case MenuType.SOrderCreate:
                    return new SOrderCreate(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderList:
                    return new SOrderList(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderSearch:
                    return new SOrderSearch(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderView:
                    return new SOrderView(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderUpdate:
                    return new SOrderUpdate(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));
                case MenuType.SOrderDelete:
                    return new SOrderDelete(new SOrderBL(new Repository<SOrder>(new StoreManagerContext(options))));

                // LINEITEM
                case MenuType.LineItemMenu:
                    return new LineItemMenu();
                case MenuType.LineItemCreate:
                    return new LineItemCreate(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));
                case MenuType.LineItemList:
                    return new LineItemList(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));
                case MenuType.LineItemSearch:
                    return new LineItemSearch(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));
                case MenuType.LineItemView:
                    return new LineItemView(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));
                case MenuType.LineItemUpdate:
                    return new LineItemUpdate(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));
                case MenuType.LineItemDelete:
                    return new LineItemDelete(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));

                // Inventory
                case MenuType.InventoryMenu:
                    return new InventoryMenu();
                case MenuType.InventoryCreate:
                    return new InventoryCreate(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));
                case MenuType.InventoryList:
                    return new InventoryList(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));
                case MenuType.InventorySearch:
                    return new InventorySearch(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));
                case MenuType.InventoryView:
                    return new InventoryView(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));
                case MenuType.InventoryUpdate:
                    return new InventoryUpdate(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));
                case MenuType.InventoryDelete:
                    return new InventoryDelete(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));

                default:
                    return new MainMenu();
            }
        }
    }
}