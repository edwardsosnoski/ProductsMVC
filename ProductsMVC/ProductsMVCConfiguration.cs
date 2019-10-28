using System;
namespace ProductsMVC
{
    public class ProductsMVCConfiguration
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string ConnectionString { get; set; }
    }
}