using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONservice.Models;

namespace JSONservice.Services
{
    public interface IProductService
    {
        Products AddProduct(Products product);
        Dictionary<string, Products> GetProducts();

        string DeleteProduct(string productName);
    }
}
