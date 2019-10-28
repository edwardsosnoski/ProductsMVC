using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsMVC.DAL;
using ProductsMVC.DAL.Models;
using ProductsMVC.Models;
using ProductsMVC.NorthwindServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsMVC.Controllers
{
    public class NorthwindController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IProductListItemService _productListItemService;
        private readonly IProductStore _productStore;

        public NorthwindController(IProductsService productsService, IProductListItemService productListItemService, IProductStore productStore)
        {
            _productsService = productsService;
            _productListItemService = productListItemService;
            _productStore = productStore;
        }

        // GET: /<controller>/
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ProductsList()
        {
            var model = _productsService.GetProducts();
            return View(model);
        }

        public IActionResult ProductListItem(int id)
        {
            var model = _productListItemService.GetProductListItem(id);
            return View(model);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult AddProductResult(AddProductViewModel model)
        {
            var productsViewModel = _productsService.AddProduct(model);
            return View("ProductsList", productsViewModel);
        }

        public IActionResult DeleteProductResult(int id)
        {
            var productViewModel = _productListItemService.GetProductListItem(id);
            var productsListViewModel = _productsService.RemoveProduct(productViewModel);
            return View("ProductsList", productsListViewModel);
        }

        public IActionResult UpdateProduct(int id)
        {
            var model = _productListItemService.GetUpdateProductView(id);
            return View(model);
        }

        public IActionResult UpdateProductResult(UpdateProductViewModel model)
        {
            var newModel = _productListItemService.EditProduct(model);
            return View("ProductListItem", newModel);
        }
    }
}