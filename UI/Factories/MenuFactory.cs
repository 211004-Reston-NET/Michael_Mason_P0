using System;
using BL;
using DL;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType menu)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

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
                
                // CATEGORY
                case MenuType.CategoryMenu:
                    return new CategoryMenu();
                case MenuType.CategoryCreate:
                    return new CategoryCreate(new CategoryBL(new CategoryRepository(new StoreManagerContext(options))));
                case MenuType.CategoryList:
                    return new CategoryList(new CategoryBL(new CategoryRepository(new StoreManagerContext(options))));
                case MenuType.CategorySearch:
                    return new CategorySearch(new CategoryBL(new CategoryRepository(new StoreManagerContext(options))));
                case MenuType.CategoryView:
                    return new CategoryView(new CategoryBL(new CategoryRepository(new StoreManagerContext(options))));
                case MenuType.CategoryUpdate:
                    return new CategoryUpdate(new CategoryBL(new CategoryRepository(new StoreManagerContext(options))));
                
                // PRODUCT
                case MenuType.ProductMenu:
                    return new ProductMenu();
                case MenuType.ProductCreate:
                    return new ProductCreate(new ProductBL(new ProductRepository(new StoreManagerContext(options))));
                case MenuType.ProductList:
                    return new ProductList(new ProductBL(new ProductRepository(new StoreManagerContext(options))));
                case MenuType.ProductSearch:
                    return new ProductSearch(new ProductBL(new ProductRepository(new StoreManagerContext(options))));
                case MenuType.ProductView:
                    return new ProductView(new ProductBL(new ProductRepository(new StoreManagerContext(options))));
                case MenuType.ProductUpdate:
                    return new ProductUpdate(new ProductBL(new ProductRepository(new StoreManagerContext(options))));
                case MenuType.ProductDelete:
                    return new ProductDelete(new ProductBL(new ProductRepository(new StoreManagerContext(options))));

                // PRODCAT
                case MenuType.ProdCatMenu:
                    return new ProdCatMenu();
                case MenuType.ProdCatCreate:
                    return new ProdCatCreate(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));
                case MenuType.ProdCatList:
                    return new ProdCatList(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));
                case MenuType.ProdCatSearch:
                    return new ProdCatSearch(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));
                case MenuType.ProdCatView:
                    return new ProdCatView(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));
                case MenuType.ProdCatUpdate:
                    return new ProdCatUpdate(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));
                case MenuType.ProdCatDelete:
                    return new ProdCatDelete(new ProdCatBL(new ProdCatRepository(new StoreManagerContext(options))));

                // STOREFRONT
                case MenuType.StorefrontMenu:
                    return new StorefrontMenu();
                case MenuType.StorefrontCreate:
                    return new StorefrontCreate(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));
                case MenuType.StorefrontList:
                    return new StorefrontList(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));
                case MenuType.StorefrontSearch:
                    return new StorefrontSearch(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));
                case MenuType.StorefrontView:
                    return new StorefrontView(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));
                case MenuType.StorefrontUpdate:
                    return new StorefrontUpdate(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));
                case MenuType.StorefrontDelete:
                    return new StorefrontDelete(new StorefrontBL(new StorefrontRepository(new StoreManagerContext(options))));

                //CUSTOMER
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.CustomerCreate:
                    return new CustomerCreate(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));
                case MenuType.CustomerList:
                    return new CustomerList(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));
                case MenuType.CustomerSearch:
                    return new CustomerSearch(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));
                case MenuType.CustomerView:
                    return new CustomerView(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));
                case MenuType.CustomerUpdate:
                    return new CustomerUpdate(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));
                case MenuType.CustomerDelete:
                    return new CustomerDelete(new CustomerBL(new CustomerRepository(new StoreManagerContext(options))));

                // SOrder
                case MenuType.SOrderMenu:
                    return new SOrderMenu();
                case MenuType.SOrderCreate:
                    return new SOrderCreate(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));
                case MenuType.SOrderList:
                    return new SOrderList(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));
                case MenuType.SOrderSearch:
                    return new SOrderSearch(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));
                case MenuType.SOrderView:
                    return new SOrderView(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));
                case MenuType.SOrderUpdate:
                    return new SOrderUpdate(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));
                case MenuType.SOrderDelete:
                    return new SOrderDelete(new SOrderBL(new SOrderRepository(new StoreManagerContext(options))));

                // LINEITEM
                case MenuType.LineItemMenu:
                    return new LineItemMenu();
                case MenuType.LineItemCreate:
                    return new LineItemCreate(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));
                case MenuType.LineItemList:
                    return new LineItemList(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));
                case MenuType.LineItemSearch:
                    return new LineItemSearch(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));
                case MenuType.LineItemView:
                    return new LineItemView(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));
                case MenuType.LineItemUpdate:
                    return new LineItemUpdate(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));
                case MenuType.LineItemDelete:
                    return new LineItemDelete(new LineItemBL(new LineItemRepository(new StoreManagerContext(options))));

                // Inventory
                case MenuType.InventoryMenu:
                    return new InventoryMenu();
                case MenuType.InventoryCreate:
                    return new InventoryCreate(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));
                case MenuType.InventoryList:
                    return new InventoryList(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));
                case MenuType.InventorySearch:
                    return new InventorySearch(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));
                case MenuType.InventoryView:
                    return new InventoryView(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));
                case MenuType.InventoryUpdate:
                    return new InventoryUpdate(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));
                case MenuType.InventoryDelete:
                    return new InventoryDelete(new InventoryBL(new InventoryRepository(new StoreManagerContext(options))));

                default:
                    return new MainMenu();
            }
        }
    }
}