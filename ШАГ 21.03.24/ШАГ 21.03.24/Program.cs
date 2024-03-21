using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_21._03._24
{
    internal class Program
    {
        static void print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static bool filtration(int number, string condition)
        {
            string[] parts = condition.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
                return false;

            if (!int.TryParse(parts[2], out int value))
                return false;

            switch (parts[1])
            {
                case ">":
                    return number > value;
                case "<":
                    return number < value;
                case ">=":
                    return number >= value;
                case "<=":
                    return number <= value;
                case "==":
                    return number == value;
                case "!=":
                    return number != value;
                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            List<int> num = new List<int>();
            Console.WriteLine("Введіть числа для створення колекції(щоб завершити .):");
            string input;
            while ((input = Console.ReadLine()) != ".")
            {
                if (int.TryParse(input, out int number))
                {
                    num.Add(number);
                }
                else
                {
                    Console.WriteLine("Невірний формат числа.");
                }
            }
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню операцій:");
                Console.WriteLine("1. Фільтрація");
                Console.WriteLine("2. Сортування");
                Console.WriteLine("3. Групування");
                Console.WriteLine("4. Вихід");

                Console.Write("Виберіть операцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть умову для фільтрації (наприклад, число > 5): ");
                        string filterCondition = Console.ReadLine();
                        var filteredNumbers = num.Where(x => filtration(x, filterCondition));
                        Console.WriteLine("Результати фільтрації:");
                        print(filteredNumbers);
                        break;
                    case "2":
                        Console.WriteLine("Виберіть спосіб сортування:");
                        Console.WriteLine("1. За зростанням");
                        Console.WriteLine("2. За спаданням");
                        Console.Write("Ваш вибір: ");
                        string sortChoice = Console.ReadLine();
                        if (sortChoice == "1")
                        {
                            num.Sort();
                        }
                        else if (sortChoice == "2")
                        {
                            num.Sort((x, y) => y.CompareTo(x));
                        }
                        Console.WriteLine("Результати сортування:");
                        print(num);
                        break;
                    case "3":
                        var groupedNumbers = num.GroupBy(x => x % 2 == 0 ? "Парні" : "Непарні");
                        Console.WriteLine("Результати групування:");
                        foreach (var group in groupedNumbers)
                        {
                            Console.WriteLine($"{group.Key}: {string.Join(", ", group)}");
                        }
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невідома операція.");
                        break;
                }
            }
        }
    }
}
