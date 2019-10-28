using System;
using ProductsMVC.Models;

namespace ProductsMVC.NorthwindServices
{
    public interface IProductsService
    {
        ProductsListViewModel GetProducts();
        ProductsListViewModel AddProduct(AddProductViewModel model);
        ProductsListViewModel RemoveProduct(ProductListItemViewModel model);
    }
}