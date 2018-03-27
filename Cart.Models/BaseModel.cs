using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Models {
    public class BaseModel {

        public long? ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }

    }
}
