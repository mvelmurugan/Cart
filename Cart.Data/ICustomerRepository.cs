using System;
using System.Collections.Generic;
using System.Text;
using Cart.Models;

namespace Cart.Data {
    public interface ICustomerRepository {

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(long id);

    }
}
