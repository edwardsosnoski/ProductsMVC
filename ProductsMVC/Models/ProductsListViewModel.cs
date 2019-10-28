using System;
using System.Collections.Generic;

namespace ProductsMVC.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductListItemViewModel> ProductsList { get; set; }
    }
}