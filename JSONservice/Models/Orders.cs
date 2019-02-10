using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONservice.Models
{
    public class Orders
    {
        private static int _idCounter = 0;
        public Orders()
        {
            Id = _idCounter++;
            ProductList = new List<Products>();
        }
        public int Id { get; private set; }

        public List<Products> ProductList { get; set; }

        public double FullOrderPrice { get; set; }

    }
}
