using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONservice.Models;

namespace JSONservice.Services
{
    public class OrderService : IOrderService
    {
        private Dictionary<int, Orders> _orders; // OrderId -- OrderObject

        public OrderService()
        {
            _orders = new Dictionary<int, Orders>();
        }

        public Orders AddOrder(Orders order)
        {
            _orders.Add(order.Id, order);

            return order;
        }

        public string DeleteOrder(int orderId)
        {
            _orders.Remove(orderId);
            return $"Order {orderId} deleted successfully";
        }

        public Dictionary<int, Orders> GetOrders()
        {
            return _orders;
        }
    }
}
