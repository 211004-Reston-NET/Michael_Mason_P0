using System;

namespace UI
{
    public enum MenuType
    {
        MainMenu,
        ExitMenu,

        //CATEGORY
        CategoryMenu,
        CategoryCreate,
        CategoryList,
        CategorySearch,
        CategoryView,
        CategoryUpdate,

        //PRODUCT
        ProductMenu,
        ProductCreate,
        ProductList,
        ProductSearch,
        ProductView,
        ProductUpdate,
        ProductDelete,

        //PRODCAT
        ProdCatMenu,
        ProdCatCreate,
        ProdCatList,
        ProdCatSearch,
        ProdCatUpdate,
        ProdCatView,
        ProdCatDelete,

        //STORE
        StorefrontMenu,
        StorefrontCreate,
        StorefrontList,
        StorefrontSearch,
        StorefrontUpdate,
        StorefrontView,
        StorefrontDelete,

        //CUSTOMER
        CustomerMenu,
        CustomerCreate,
        CustomerList,
        CustomerSearch,
        CustomerUpdate,
        CustomerView,
        CustomerDelete,

    //LINEITEM
        LineItemMenu,
        LineItemCreate,
        LineItemList,
        LineItemSearch,
        LineItemUpdate,
        LineItemView,
        LineItemDelete,

        //STORE
        SOrderMenu,
        SOrderCreate,
        SOrderList,
        SOrderSearch,
        SOrderUpdate,
        SOrderView,
        SOrderDelete,

        //INVENTORY
        InventoryMenu,
        InventoryCreate,
        InventoryList,
        InventorySearch,
        InventoryUpdate,
        InventoryView,
        InventoryDelete
    }

    public interface IMenu
    {
        void Menu();
        MenuType UserSelection();
    }
}