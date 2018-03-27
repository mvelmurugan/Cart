using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cart.Models;

namespace Cart.Data {
    public class MockCustomerRepository : ICustomerRepository {

        static List<Customer> items;

        static MockCustomerRepository() {
            items = new List<Customer>{
                new Customer { ID = 1, Name = "First Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 2, Name = "Second Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 3, Name = "Third Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 4, Name = "Fourth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 5, Name = "Fifth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 6, Name = "Sixth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 7, Name = "Seventh Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 8, Name = "Eigth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 9, Name = "Nineth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now },
                new Customer { ID = 10, Name = "Tenth Customer", Address = "London", CreatedBy = 1, CreatedOn = DateTime.Now }
            };
        }

        public IEnumerable<Customer> GetCustomers() {
            return items;
        }

        public Customer GetCustomer(long id) {
            return items
                .Where(customer => customer.ID == id)
                .FirstOrDefault();
        }

    }
}
