using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Models {
    public class OrderProduct : BaseModel {

        public long ProductID { get; set; }

        public int Quantity { get; set; }

        public double ListPrice { get; set; }

        public double UnitPrice { get; set; }

        public double Discount { get; set; }

        public double Subtotal {
            get {
                return UnitPrice * ((100d - Discount) / 100.0);
            }
        }

        public double TotalPrice {
            get {
                return Quantity * Subtotal;
            }
        }
    }
}
