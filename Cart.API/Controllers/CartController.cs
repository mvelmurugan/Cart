using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cart.Components;
using Cart.Models;
using System.Text;
using Cart.API.RequestModels;

namespace Cart.API.Controllers {
    [Produces("application/json")]
    [Route("api/Cart")]
    public class CartController : Controller {

        OrderComponent orderComponent;
        public CartController(OrderComponent orderComponent) {
            this.orderComponent = orderComponent;
        }

        [HttpGet("{customerId}")]
        public Order Get(long customerId) {
            return orderComponent.GetOrder(customerId);
        }

        //[HttpPut]
        //public Order Put(long? productId , int quantity) {             
        //    if (!productId.HasValue) return orderComponent.UpdateQuantity(CustomerID, quantity);
        //    return orderComponent.UpdateProduct(CustomerID, productId.Value, quantity);
        //}

        [HttpPut("{customerId}")]
        public Order Put( long customerId,PutModel input)
        { 
            if (!input.ProductID.HasValue) return orderComponent.UpdateQuantity(customerId, input.Quantity);
            return orderComponent.UpdateProduct(customerId, input.ProductID.Value, input.Quantity);
        }

        [HttpDelete("{customerId}")]
        public Order Delete(long customerId, long? productId = null) {
            if (!productId.HasValue) return orderComponent.DeleteOrder(customerId);
            return orderComponent.DeleteProduct(customerId, productId.Value);
        }
         
        
    }
}