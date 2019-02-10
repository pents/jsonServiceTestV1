using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONservice.Models;
using JSONservice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSONservice.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class JSONController : ControllerBase
    {
        private IProductService _serviceProduct;
        private IOrderService _serviceOrder;

        public JSONController(IProductService serviceProduct, IOrderService serviceOrder)
        {
            _serviceProduct = serviceProduct;
            _serviceOrder = serviceOrder;
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult<Products> AddProduct(Products productItems)
        {
            var products = _serviceProduct.AddProduct(productItems);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<Dictionary<string, Products>> GetProducts()
        {
            var productsList = _serviceProduct.GetProducts();

            if (productsList.Count == 0)
            {
                return NotFound();
            }

            return productsList;
        }

        [HttpPost]
        [Route("AddOrder")]
        public ActionResult<Orders> AddOrder([FromBody]string[] products)
        {
            var orderItem = new Orders();
            var productsList = _serviceProduct.GetProducts();

            foreach (var item in products)
            {
                if (productsList.ContainsKey(item))
                {
                    orderItem.ProductList.Add(productsList[item]);
                    orderItem.FullOrderPrice += productsList[item].Price;
                }
                else
                {
                    return BadRequest();
                }
            }

            if (orderItem.ProductList.Count == 0)
            {
                BadRequest();
            }

            var order = _serviceOrder.AddOrder(orderItem);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet]
        [Route("GetOrders")]
        public ActionResult<Dictionary<int, Orders>> GetOrders()
        {
            var ordersList = _serviceOrder.GetOrders();

            if (ordersList.Count == 0)
            {
                return NotFound();
            }

            return ordersList;
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public ActionResult<string> DeleteProduct([FromBody]string productName)
        {
            if (!_serviceProduct.GetProducts().ContainsKey(productName))
            {
                return BadRequest();
            }

            return _serviceProduct.DeleteProduct(productName);
        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public ActionResult<string> DeleteOrder([FromBody]int orderid)
        {
            if (!_serviceOrder.GetOrders().ContainsKey(orderid))
            {
                return BadRequest();
            }

            return _serviceOrder.DeleteOrder(orderid);
        }
    }
}