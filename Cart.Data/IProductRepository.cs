using System;
using System.Collections.Generic;
using System.Text;
using Cart.Models;

namespace Cart.Data {
    public interface IProductRepository {

        IEnumerable<Product> GetProducts();

        Product GetProduct(long id);
    }
}
