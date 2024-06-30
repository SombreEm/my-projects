using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_21._05
{
    internal class Program
    {
        public class Order
        {
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public string Status { get; set; }
        }
        public class OrderService
        {
            private List<Order> orders = new List<Order>();
            private int nextOrderId = 1;
            public Order CreateOrder(string customerName)
            {
                Order order = new Order
                {
                    OrderId = nextOrderId++,
                    CustomerName = customerName,
                    Status = "New"
                };
                orders.Add(order);
                NotifyUser(order, "created");
                return order;
            }
            public Order GetOrder(int orderId)
            {
                return orders.Find(order => order.OrderId == orderId);
            }
            public void UpdateOrderStatus(int orderId, string newStatus)
            {
                Order order = GetOrder(orderId);
                if (order != null)
                {
                    order.Status = newStatus;
                    NotifyUser(order, "updated to " + newStatus);
                }
            }
            private void NotifyUser(Order order, string message)
            {
                Console.WriteLine($"Notification: Order {order.OrderId} for {order.CustomerName} has been {message}.");
            }
        }
        public class OrderFacade
        {
            private OrderService orderService = new OrderService();
            public void PlaceOrder(string customerName)
            {
                orderService.CreateOrder(customerName);
            }
            public void CheckOrderStatus(int orderId)
            {
                Order order = orderService.GetOrder(orderId);
                if (order != null)
                {
                    Console.WriteLine($"Order {orderId} status is: {order.Status}");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            public void ChangeOrderStatus(int orderId, string newStatus)
            {
                orderService.UpdateOrderStatus(orderId, newStatus);
            }
        }
        static void Main(string[] args)
        {
            OrderFacade orderFacade = new OrderFacade();

            orderFacade.PlaceOrder("Kirill Kravets");
            orderFacade.PlaceOrder("Nikita Serchenko");

            orderFacade.CheckOrderStatus(1);
            orderFacade.ChangeOrderStatus(1, "Shipped");
            orderFacade.CheckOrderStatus(1);

            orderFacade.CheckOrderStatus(2);
            orderFacade.ChangeOrderStatus(2, "Delivered");
            orderFacade.CheckOrderStatus(2);
        }
    }
}
