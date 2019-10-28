using System;
using ProductsMVC.Models;

namespace ProductsMVC.NorthwindServices
{
    public interface IProductListItemService
    {
        ProductListItemViewModel GetProductListItem(int id);
        ProductListItemViewModel EditProduct(UpdateProductViewModel model);
        UpdateProductViewModel GetUpdateProductView(int id);
    }
}
