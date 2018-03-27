using System;
using System.Collections.Generic;
using Cart.Models;

namespace Cart.Data {

    public interface IOrderRepository {

        IEnumerable<Order> GetOrders(long customerId);

        Order Save(Order item);

        Order GetProgressOrder(long customerId);

    }

}
