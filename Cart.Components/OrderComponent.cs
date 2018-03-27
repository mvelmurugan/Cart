using System;
using System.Collections.Generic;
using System.Linq;
using Cart.Models;
using Cart.Data;

namespace Cart.Components {

    public class OrderComponent {
        IOrderRepository orderRepository;
        IProductRepository productRepository;
        ICustomerRepository customerRepository;

        public OrderComponent(IOrderRepository orderRepository, 
            IProductRepository productRepository, 
            ICustomerRepository customerRepository) {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.customerRepository = customerRepository;
        }

        public Order GetOrder(long customerId) {
            if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
            var order = orderRepository.GetProgressOrder(customerId);
            if (order == null) order = AddNewOrder(customerId);
            return order;
        }

        public Order UpdateQuantity(long customerId, int quantity) {
             if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
            var order = GetOrder(customerId);
            order.Products.ForEach(op => op.Quantity = quantity);
            return order;
        }

        public Order UpdateProduct(long customerId, long productId, int quantity) {
             if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
             if(productId == 0) throw new InvalidOperationException("Invalid Product ID");
            var order = GetOrder(customerId);
            var orderProduct = order.Products.FirstOrDefault(product => product.ID == productId);
            if(orderProduct == null) {
                orderProduct = GetOrderProduct(productId);
                order.Products.Add(orderProduct);
            }
            orderProduct.Quantity = quantity;
            return orderRepository.Save(order);
        }

        public Order DeleteOrder(long customerId) {
            if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
            var order = GetOrder(customerId);
            order.Products.RemoveAll(op => true);
            return order;
        }

        public Order DeleteProduct(long customerId, long productId) {
            if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
             if(productId == 0) throw new InvalidOperationException("Invalid Product ID");
            var order = GetOrder(customerId);
            order.Products.RemoveAll(op => op.ProductID == productId);
            return order;
        }

        Order AddNewOrder(long customerId) {
            if(customerId == 0) throw new InvalidOperationException("Invalid Customer ID");
            var item = new Order {
                CustomerID = customerId,
                Status = OrderStatuses.InProgress,
                CreatedBy = 1, CreatedOn = DateTime.Now
            };
            return orderRepository.Save(item);
        }

        OrderProduct GetOrderProduct(long productId) {
             if(productId == 0) throw new InvalidOperationException("Invalid Product ID");
            var product = productRepository.GetProduct(productId);
            if (product == null) throw new InvalidOperationException("Product not found");
            return new OrderProduct {
                ProductID = product.ID.Value, ListPrice = product.Price, UnitPrice = product.Price,
                CreatedBy = 1, CreatedOn = DateTime.Now
            };
        }
    }

}
