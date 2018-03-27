using System;
using System.Collections.Generic;
using System.Text;

namespace Cart.Models
{
    public enum OrderStatuses {
        InProgress,
        Pipeline,
        Dispatched,
        Delivered,
        Closed,
        Cancelled
    }

}
