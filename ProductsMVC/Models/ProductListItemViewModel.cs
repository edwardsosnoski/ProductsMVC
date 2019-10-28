using System;
using ProductsMVC.DAL.Models;

namespace ProductsMVC.Models
{
    public class ProductListItemViewModel
    {
        public ProductListItemViewModel(ProductDALModel dalModel)
        {
            Name = dalModel.ProductName;
            Id = dalModel.ProductID;
            SupplierId = dalModel.SupplierID;
            CategoryId = dalModel.CategoryID;
            QuantityPerUnit = dalModel.QuantityPerUnit;
            UnitPrice = dalModel.UnitPrice;
            UnitsInStock = dalModel.UnitsInStock;
            UnitsOnOrder = dalModel.UnitsOnOrder;
            ReorderLevel = dalModel.ReorderLevel;
            Discontinued = dalModel.Discontinued;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}