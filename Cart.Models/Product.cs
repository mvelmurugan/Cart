using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Models {
    public class Product : BaseModel{

        public string Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
