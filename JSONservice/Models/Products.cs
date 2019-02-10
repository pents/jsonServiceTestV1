using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONservice.Models
{
    public class Products
    {
        private static int _idCounter = 0;
        public Products()
        {
            Id = _idCounter++;
        }

        public int Id { get; private set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

    }
}
