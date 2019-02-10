using JSONservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONservice.Services
{
    public interface IOrderService
    {
        Orders AddOrder(Orders order);
        Dictionary<int, Orders> GetOrders();
        string DeleteOrder(int orderId);
    }
}
