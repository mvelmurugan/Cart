using FluentValidation.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.RequestModels {   
    public class PutModel {

        public long? ProductID { get; set; }

        [FromForm]
        public int Quantity { get; set; }
    }
}
