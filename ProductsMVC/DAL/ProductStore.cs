using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using ProductsMVC.DAL.Models;
using ProductsMVC.Models;

namespace ProductsMVC.DAL
{
    public class ProductStore : IProductStore
    {
        private readonly Database _config;

        public ProductStore(ProductsMVCConfiguration config)
        {
            _config = config.Database;
        }

        public IEnumerable<ProductDALModel> GetAllProducts()
        {
            var sql = @"SELECT * FROM Products";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Query<ProductDALModel>(sql);
                return result;
            }
        }

        public ProductDALModel GetProductDALModelById(int id)
        {
            var sql = @"SELECT * FROM Products WHERE ProductID = @ProductId";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault<ProductDALModel>(sql, new { ProductID = id });

                return result;
            }
        }

        public bool InsertNewProduct(AddProductViewModel model)
        {
            var sql = $@"INSERT INTO Products (
                            ProductName,
                            QuantityPerUnit,
                            UnitPrice,
                            UnitsInStock,
                            UnitsOnOrder,
                            ReorderLevel,
                            Discontinued
                        )
                        VALUES (
                            @{nameof(model.Name)},
                            @{nameof(model.QuantityPerUnit)},
                            @{nameof(model.UnitPrice)},
                            @{nameof(model.UnitsInStock)},
                            @{nameof(model.UnitsOnOrder)},
                            @{nameof(model.ReorderLevel)},
                            @{nameof(model.Discontinued)}
                        )";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                try
                {
                    var result = connection.Execute(sql, model);
                    return true;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public bool DeleteProduct(ProductListItemViewModel model)
        {
            var sql = $@"DELETE FROM Products
                        WHERE ProductID = @{nameof(model.Id)}";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                try
                {
                    var result = connection.Execute(sql, model);
                    return true;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public bool UpdateProduct(UpdateProductViewModel model)
        {
            var sql = $@"UPDATE Products
            SET ProductName = @{nameof(model.Name)},
            QuantityPerUnit = @{nameof(model.QuantityPerUnit)},
            UnitPrice = @{nameof(model.UnitPrice)},
            UnitsInStock = @{nameof(model.UnitsInStock)},
            UnitsOnOrder = @{nameof(model.UnitsOnOrder)},
            ReorderLevel = @{nameof(model.ReorderLevel)},
            Discontinued = @{nameof(model.Discontinued)}
            WHERE ProductID = @{nameof(model.Id)}";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                try
                {
                    var result = connection.Execute(sql, model);
                    return true;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}