using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_18._01._24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Завдання 1: Введіть число від 1 до 100:");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number >= 1 && number <= 100)
                {
                    if (number % 3 == 0 && number % 5 == 0)
                        Console.WriteLine("FizzBuzz");
                    else if (number % 3 == 0)
                        Console.WriteLine("Fizz");
                    else if (number % 5 == 0)
                        Console.WriteLine("Buzz");
                    else
                        Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Введіть число від 1 до 100.");
                }
            }
            else
            {
                Console.WriteLine("Повинне бути ціле число");
            }

            Console.WriteLine();

            Console.WriteLine("Завдання 2: Введіть два числа.");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            if (numbers.Length == 2 && int.TryParse(numbers[0], out int num1) && int.TryParse(numbers[1], out int num2))
            {
                double result = (double)num1 * num2 / 100;
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Треба виваести два числа через пробіл.");
            }
        }
    }
}
