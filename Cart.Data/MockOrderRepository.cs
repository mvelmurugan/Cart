using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cart.Models;

namespace Cart.Data {
    public class MockOrderRepository : IOrderRepository {

        static List<Order> items;

        static MockOrderRepository() {
            items = new List<Order>();
        }

        public IEnumerable<Order> GetOrders(long customerId) {
            return items
                .Where(order => order.CustomerID == customerId);
        }

        public Order Save(Order item) {
            if (!item.ID.HasValue) item.ID = items.Count + 1;
            items = items
                .Where(order => order.ID != item.ID)
                .ToList();
            items.Add(item);
            return item;
        }

        public Order GetProgressOrder(long customerId) {
            return items
                .Where(order => order.CustomerID == customerId && order.Status == OrderStatuses.InProgress)
                .FirstOrDefault();
        }

    }
}
