using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_18._01._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Завдання 3: Введіть чотири цифри (через пробіл):");
            string input = Console.ReadLine();
            string[] digits = input.Split(' ');

            if (digits.Length == 4 && int.TryParse(digits[0], out int digit1) &&
                int.TryParse(digits[1], out int digit2) && int.TryParse(digits[2], out int digit3) &&
                int.TryParse(digits[3], out int digit4))
            {
                Console.WriteLine($"Сформоване число: {digit1}{digit2}{digit3}{digit4} ");
            }
            else
            {
                Console.WriteLine("Помилка: Введіть чотири цифри через пробіл.");
            }

            Console.WriteLine();

            Console.WriteLine("Завдання 4: Введіть шестизначне число:");
            string inputNumber = Console.ReadLine();
            if (inputNumber.Length == 6 && int.TryParse(inputNumber, out int number))
            {
                Console.WriteLine("Введіть номери розрядів для заміни цифр (через пробіл):");
                string inputIndices = Console.ReadLine();
                string[] indices = inputIndices.Split(' ');
                if (indices.Length == 2 && int.TryParse(indices[0], out int index1) && int.TryParse(indices[1], out int index2) &&
                    index1 >= 1 && index1 <= 6 && index2 >= 1 && index2 <= 6)
                {
                    char[] digitsArray = inputNumber.ToCharArray();
                    char temp = digitsArray[index1 - 1];
                    digitsArray[index1 - 1] = digitsArray[index2 - 1];
                    digitsArray[index2 - 1] = temp;
                    int newNumber = int.Parse(new string(digitsArray));
                    Console.WriteLine($"Нове число: {newNumber}");
                }
                else
                {
                    Console.WriteLine("Введіть два різних номери розрядів.");
                }
            }
            else
            {
                Console.WriteLine("Введіть шестизначне число.");
            }
        }
    }
}
