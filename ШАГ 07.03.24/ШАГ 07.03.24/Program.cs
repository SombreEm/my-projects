using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_07._03._24
{
    internal class Program
    {

        class Product
        {
            public string Name { get; set; }
            public double CostPrice { get; set; }
            public double SellingPrice { get; set; }
            public Product(string name, double costPrice, double sellingPrice)
            {
                Name = name;
                CostPrice = costPrice;
                SellingPrice = sellingPrice;
            }
        }
        class Warehouse
        {
            private List<Product> products = new List<Product>();

            public void AddProduct(Product product)
            {
                products.Add(product);
            }
            public void DisplayProducts()
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Name} - Ціна: {products[i].SellingPrice} грн");
                }
            }

            public bool IsValidProductI(int index)
            {
                return index >= 0 && index < products.Count;
            }

            static void Main(string[] args)
            {
            }
        }
        class CashRegister
        {
            private double balance;
            public void ProcessPayment(double amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"Оплата прийнята. Залишок {balance} грн");
                }
                else
                {
                    Console.WriteLine("Недостатньо коштів для здійснення оплати.");
                }
            }
            static void Main()
            {
                Warehouse warehouse = new Warehouse();
                warehouse.AddProduct(new Product("Молоко", 100, 150));
                warehouse.AddProduct(new Product("Снікерс", 50, 80));
                warehouse.AddProduct(new Product("Баунті", 200, 300));
                CashRegister cashRegister = new CashRegister();
            }
        }
    }
}
