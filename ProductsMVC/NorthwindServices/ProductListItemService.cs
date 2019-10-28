using System;
using ProductsMVC.DAL;
using ProductsMVC.DAL.Models;
using ProductsMVC.Models;

namespace ProductsMVC.NorthwindServices
{
    public class ProductListItemService : IProductListItemService
    {
        private readonly IProductStore _productStore;

        public ProductListItemService(IProductStore productStore)
        {
            _productStore = productStore;
        }

        public ProductListItemViewModel GetProductListItem(int id)
        {
            var dalProduct = _productStore.GetProductDALModelById(id);
            var product = new ProductListItemViewModel(dalProduct);
            return product;
        }

        public UpdateProductViewModel GetUpdateProductView(int id)
        {
            var dalProduct = _productStore.GetProductDALModelById(id);
            var updateProduct = new UpdateProductViewModel()
            {
                Id = dalProduct.ProductID
            };

            return updateProduct;
        }

        public ProductListItemViewModel EditProduct(UpdateProductViewModel model)
        {
            _productStore.UpdateProduct(model);
            var dalModel = _productStore.GetProductDALModelById(model.Id);
            var newModel = new ProductListItemViewModel(dalModel);
            return newModel;
        }
    }
}