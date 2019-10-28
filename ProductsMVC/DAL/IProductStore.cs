using System;
using System.Collections.Generic;
using ProductsMVC.DAL.Models;
using ProductsMVC.Models;

namespace ProductsMVC.DAL
{
    public interface IProductStore
    {
        IEnumerable<ProductDALModel> GetAllProducts();
        ProductDALModel GetProductDALModelById(int id);
        bool InsertNewProduct(AddProductViewModel model);
        bool DeleteProduct(ProductListItemViewModel model);
        bool UpdateProduct(UpdateProductViewModel model);
    }
}