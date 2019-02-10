using System;
using Xunit;
using JSONservice.Controllers;
using JSONservice.Services;
using JSONservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceTest
{
    public class UnitTest1
    {
        private JSONController _controller;
        private OrderService _orderService;
        private ProductService _productService;
        public UnitTest1()
        {
            _orderService = new OrderService();
            _productService = new ProductService();
            _controller = new JSONController(_productService, _orderService);
        }

        private Products createProduct(string name)
        {
            var prod = new Products
            {
                Price = 100,
                ProductName = name
            };
            return prod;
        }

        [Fact]
        public void PostProductTest()
        {
            var prod = createProduct("Lays");

            var result = _controller.AddProduct(prod);

            Assert.Equal(prod, result.Value);
        }

        [Fact]
        public void GetProductTest()
        {
            _controller.AddProduct(createProduct("Pringles"));

            var result = _controller.GetProducts().Value.ContainsKey("Pringles");

            Assert.True(result);
        }

        [Fact]
        public void PostOrderTest()
        {
            _controller.AddProduct(createProduct("Cola"));
            var result = _controller.AddOrder(new string[] { "Cola" });

            Assert.Single(_controller.GetOrders().Value);
        }

        [Fact]
        public void GetOrderTest()
        {
            _controller.AddProduct(createProduct("Pepsi"));
            

            var orderAssert = _controller.AddOrder(new string[] { "Pepsi" });

            var result = _controller.GetOrders().Value.ContainsValue(orderAssert.Value);

            Assert.True(result);
        }

        [Fact]
        public void DeleteOrderTest()
        {
            _controller.AddProduct(createProduct("RedBull"));
            var orderAssert = _controller.AddOrder(new string[] { "RedBull" });
            var result = _controller.DeleteOrder(orderAssert.Value.Id);

            Assert.False(_orderService.GetOrders().ContainsKey(orderAssert.Value.Id));
        }

        [Fact]
        public void DeleteProductTest()
        {
            _controller.AddProduct(createProduct("Chocolate"));
            var result = _controller.DeleteProduct("Chocolate");

            Assert.False(_productService.GetProducts().ContainsKey("Chocolate"));
        }
    }
}
