using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Models {
    public class Order : BaseModel {

        public Order() {
            Products = new List<OrderProduct>();
        }

        public long CustomerID { get; set; }

        public OrderStatuses Status { get; set; }

        public List<OrderProduct> Products { get; private set; }
    }
}
