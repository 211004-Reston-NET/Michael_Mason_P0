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
                default:
                    return new MainMenu();

                // PRODUCT
            }
        }
    }
}