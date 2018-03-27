using Cart.Components;
using Cart.Data;
using Cart.Models;
using Cart.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Cart.API.RequestModels;

namespace Cart.Tests {

    public class CartControllerTests {

        [Fact]
        public void Get_Orders_With_CustomerId()
        {
            var controller = GetController();
            var result = controller.Get(1);
            Assert.Equal(OrderStatuses.InProgress, result.Status);
            Assert.True(result.Products.Count == 0 );
        }

        [Fact]
        public void Put_Orders_Products_With_CustomerID()
        {
            var controller = GetController();
            PutModel putModel = new PutModel();
            putModel.ProductID = 1;
            putModel.Quantity = 10;

            controller.Get(1);
            var result  =  controller.Put(1, putModel);

            
            Assert.True(result.Products.Count == 1);
            Assert.Equal(10, result.Products[0].Quantity);
            
        }

        [Fact]
        public void Delete_Orders_Products_With_CustomerID()
        {
            Put_Orders_Products_With_CustomerID();
            var controller = GetController();           
            var result = controller.Delete(1, 1);
            Assert.True(result.Products.Count == 0);          
        }

        CartController GetController()
        {
            return new CartController(
                new OrderComponent(
                     new MockOrderRepository(),
                     new MockProductRepository(),
                     new MockCustomerRepository()
                )
            );
        }


    }
}
