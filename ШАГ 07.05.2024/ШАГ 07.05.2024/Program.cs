using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_07._05._2024
{
    internal class Program
    {
        public class MenuItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public MenuItem(string name, decimal price, string description)
            {
                Name = name;
                Price = price;
                Description = description;
            }
            public virtual decimal GetPrice()
            {
                return Price;
            }
            public virtual void ShowDetails()
            {
                Console.WriteLine($"{Name}: {Description} - {Price:C}");
            }
        }
        public class Menu
        {
            private List<MenuItem> _items;
            public Menu()
            {
                _items = new List<MenuItem>();
            }
            public void AddItem(MenuItem item)
            {
                _items.Add(item);
            }
            public void RemoveItem(MenuItem item)
            {
                _items.Remove(item);
            }
            public List<MenuItem> GetItems()
            {
                return _items;
            }
        }
        public abstract class IngredientDecorator : MenuItem
        {
            protected MenuItem _menuItem;
            public IngredientDecorator(MenuItem menuItem) : base(menuItem.Name, menuItem.Price, menuItem.Description)
            {
                _menuItem = menuItem;
            }
            public override void ShowDetails()
            {
                _menuItem.ShowDetails();
            }
        }
        public class Cheese : IngredientDecorator
        {
            public Cheese(MenuItem menuItem) : base(menuItem)
            {
                Name = menuItem.Name + ", Cheese";
                Price = menuItem.GetPrice() + 0.50m;
            }
            public override decimal GetPrice()
            {
                return _menuItem.GetPrice() + 0.50m;
            }
        }
        public class Bacon : IngredientDecorator
        {
            public Bacon(MenuItem menuItem) : base(menuItem)
            {
                Name = menuItem.Name + ", Bacon";
                Price = menuItem.GetPrice() + 1.00m;
            }
            public override decimal GetPrice()
            {
                return _menuItem.GetPrice() + 1.00m;
            }
        }
        public abstract class Order
        {
            protected List<MenuItem> _items;

            public Order()
            {
                _items = new List<MenuItem>();
            }
            public void AddItem(MenuItem item)
            {
                _items.Add(item);
            }
            public void AddIngredient(MenuItem item, IngredientDecorator ingredient)
            {
                _items.Remove(item);
                _items.Add(ingredient);
            }
            public List<MenuItem> GetItems()
            {
                return _items;
            }

            public decimal GetTotalPrice()
            {
                return _items.Sum(item => item.GetPrice());
            }
            public abstract void ShowOrderDetails();
        }
        public class OrderStatus
        {
            public string Status { get; private set; }
            public OrderStatus(string status)
            {
                Status = status;
            }
        }
        public class Customer
        {
            public void Update(OrderStatus status)
            {
                Console.WriteLine($"Order status updated: {status.Status}");
            }
        }
        public class OrderStatusNotifier
        {
            private List<Customer> _observers;
            private OrderStatus _orderStatus;
            public OrderStatusNotifier()
            {
                _observers = new List<Customer>();
            }
            public void RegisterObserver(Customer observer)
            {
                _observers.Add(observer);
            }
            public void UnregisterObserver(Customer observer)
            {
                _observers.Remove(observer);
            }
            public void NotifyObservers()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(_orderStatus);
                }
            }
            public void UpdateStatus(OrderStatus status)
            {
                _orderStatus = status;
                NotifyObservers();
            }
        }
        public class TakeawayOrder : Order
        {
            public override void ShowOrderDetails()
            {
                Console.WriteLine("Takeaway Order:");
                foreach (var item in _items)
                {
                    item.ShowDetails();
                }
                Console.WriteLine($"Total Price: {GetTotalPrice():C}");
            }
        }
        public class DeliveryOrder : Order
        {
            public override void ShowOrderDetails()
            {
                Console.WriteLine("Delivery Order:");
                foreach (var item in _items)
                {
                    item.ShowDetails();
                }
                Console.WriteLine($"Total Price: {GetTotalPrice():C}");
            }
        }
        public abstract class OrderFactory
        {
            public abstract Order CreateOrder();
        }
        public class TakeawayOrderFactory : OrderFactory
        {
            public override Order CreateOrder()
            {
                return new TakeawayOrder();
            }
        }
        public class DeliveryOrderFactory : OrderFactory
        {
            public override Order CreateOrder()
            {
                return new DeliveryOrder();
            }
        }
        static void Main(string[] args)
        {
            var menu = new Menu();
            var burger = new MenuItem("Burger", 5.00m, "Classic beef burger");
            var pizza = new MenuItem("Pizza", 8.00m, "Cheese pizza with tomato sauce");
            menu.AddItem(burger);
            menu.AddItem(pizza);
            var takeawayFactory = new TakeawayOrderFactory();
            var takeawayOrder = takeawayFactory.CreateOrder();
            takeawayOrder.AddItem(burger);
            takeawayOrder.AddItem(new Cheese(pizza)); 
            takeawayOrder.ShowOrderDetails();
            var deliveryFactory = new DeliveryOrderFactory();
            var deliveryOrder = deliveryFactory.CreateOrder();
            deliveryOrder.AddItem(pizza);
            deliveryOrder.AddItem(new Bacon(burger)); 
            deliveryOrder.ShowOrderDetails();
            var customer = new Customer();
            var orderStatusNotifier = new OrderStatusNotifier();
            orderStatusNotifier.RegisterObserver(customer);
            orderStatusNotifier.UpdateStatus(new OrderStatus("Очікується"));
            orderStatusNotifier.UpdateStatus(new OrderStatus("Готується"));
            orderStatusNotifier.UpdateStatus(new OrderStatus("Готове"));
        }
    }
}
