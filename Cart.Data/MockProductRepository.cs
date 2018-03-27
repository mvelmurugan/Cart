using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cart.Models;

namespace Cart.Data {
    public class MockProductRepository : IProductRepository {

        static List<Product> items;

        static MockProductRepository() {
            items = new List<Product>{
                new Product { ID = 1, Code="P1", Name = "Product 1", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 2, Code="P2", Name = "Product 2", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 3, Code="P3", Name = "Product 3", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 4, Code="P4", Name = "Product 4", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 5, Code="P5", Name = "Product 5", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 6, Code="P6", Name = "Product 6", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 7, Code="P7", Name = "Product 7", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 8, Code="P8", Name = "Product 8", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 9, Code="P9", Name = "Product 9", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now },
                new Product { ID = 10, Code="P10", Name = "Product 10", Price = 1, CreatedBy = 1, CreatedOn = DateTime.Now }
            };
        }

        public IEnumerable<Product> GetProducts() {
            return items;
        }

        public Product GetProduct(long id) {
            return items
                .Where(product => product.ID == id)
                .FirstOrDefault();
        }

    }
}
