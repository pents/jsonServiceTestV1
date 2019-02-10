using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONservice.Models;

namespace JSONservice.Services
{
    public class ProductService : IProductService
    {
        private Dictionary<string, Products> _products; // ProductName -- ProductObject


        public ProductService()
        {
            _products = new Dictionary<string, Products>();
            
        }

        public Products AddProduct(Products product)
        {
            _products.Add(product.ProductName, product);

            return product;
        }



        public string DeleteProduct(string productName)
        {
            _products.Remove(productName);
            return $"Product {productName} deleted successfully";
        }



        public Dictionary<string, Products> GetProducts()
        {
            return _products;
        }
    }
}
