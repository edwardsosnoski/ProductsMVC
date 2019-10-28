using System;
using System.Collections.Generic;
using ProductsMVC.DAL;
using ProductsMVC.Models;

namespace ProductsMVC.NorthwindServices
{
    public class ProductsService : IProductsService
    {
        private readonly IProductStore _productStore;

        public ProductsService(IProductStore productStore)
        {
            _productStore = productStore;
        }

        public ProductsListViewModel GetProducts()
        {
            var dalProducts = _productStore.GetAllProducts();
            var productsList = new List<ProductListItemViewModel>();

            foreach (var dalProduct in dalProducts)
            {
                productsList.Add(new ProductListItemViewModel(dalProduct));
            }

            var productsListViewModel = new ProductsListViewModel();
            productsListViewModel.ProductsList = productsList;

            return productsListViewModel;
        }

        public ProductsListViewModel AddProduct(AddProductViewModel model)
        {
            _productStore.InsertNewProduct(model);
            var dalProducts = _productStore.GetAllProducts();
            var productsList = new List<ProductListItemViewModel>();

            foreach (var dalProduct in dalProducts)
            {
                productsList.Add(new ProductListItemViewModel(dalProduct));
            }

            var productsListViewModel = new ProductsListViewModel();
            productsListViewModel.ProductsList = productsList;

            return productsListViewModel;
        }

        public ProductsListViewModel RemoveProduct(ProductListItemViewModel model)
        {
            _productStore.DeleteProduct(model);
            var dalProducts = _productStore.GetAllProducts();
            var productsList = new List<ProductListItemViewModel>();

            foreach (var dalProduct in dalProducts)
            {
                productsList.Add(new ProductListItemViewModel(dalProduct));
            }

            var productsListViewModel = new ProductsListViewModel();
            productsListViewModel.ProductsList = productsList;

            return productsListViewModel;
        }
    }
}