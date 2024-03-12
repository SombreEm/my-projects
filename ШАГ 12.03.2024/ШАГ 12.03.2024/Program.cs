using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_12._03._2024
{

    class CollectionManager<T>
    {
        private List<T> collection = new List<T>();

        public void AddItem(T item)
        {
            collection.Add(item);
        }

        public void RemoveItem(T item)
        {
            collection.Remove(item);
        }

        public void DisplayItems()
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Колекція цілих чисел");
            Console.WriteLine("2. Колекція рядків");
            Console.WriteLine("3. Колекція об'єктів");

            Console.Write("Оберіть тип колекції: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CollectionManager<int> iColManager = new CollectionManager<int>();
                    PerformOperations(iColManager);
                    break;
                case 2:
                    CollectionManager<string> sColManager = new CollectionManager<string>();
                    PerformOperations(sColManager);
                    break;
                case 3:
                    CollectionManager<object> oColManager = new CollectionManager<object>();
                    PerformOperations(oColManager);
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }

        static void PerformOperations<T>(CollectionManager<T> manager)
        {
            while (true)
            {
                Console.WriteLine("1. Введіть елемент для додавання:");
                Console.WriteLine("2. Введіть елемент для видалення:");
                Console.WriteLine("3. Елементи у колекції:");
                Console.WriteLine("4. Вихід");

                Console.Write("Оберіть операцію: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть елемент для додавання: ");
                        T newItem = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        manager.AddItem(newItem);
                        break;
                    case 2:
                        Console.Write("Введіть елемент для видалення: ");
                        T itemToRemove = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        manager.RemoveItem(itemToRemove);
                        break;
                    case 3:
                        Console.WriteLine("Елементи у колекції:");
                        manager.DisplayItems();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }
    }
}
