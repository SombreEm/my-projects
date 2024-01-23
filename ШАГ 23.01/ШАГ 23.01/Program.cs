using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_23._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] one = new int[5];
            //int[] two = new int[5];
            //int[] three = new int[5];

            //Console.WriteLine(" ");
            //for (int i = 0; i < one.Length; i++)
            //{
            //    Console.Write($"{i + 1} ");
            //    one[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine(" ");
            //for (int i = 0; i < two.Length; i++)
            //{
            //    Console.Write($"{i + 1} ");
            //    two[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //for (int i = 0; i < three.Length; i++)
            //{
            //    three[i] = one[i] + two[i];
            //}

            //Console.WriteLine(" ");
            //for (int i = 0; i < three.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1} {three[i]}");
            //}
            ////////-----------------------------------
            //Console.Write("кількість рядків: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //string[] stringsArray = new string[n];
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write($"введіть рядок {i + 1}: ");
            //    stringsArray[i] = Console.ReadLine();
            //}
            //Console.WriteLine(" ");
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"{i + 1} {stringsArray[i]}");
            //}
            //------------------------------------------

            Console.Write("число від 0 до 100000: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 0 || number > 100000)
            {
                Console.WriteLine("Невірне число");
            }
            else
            {
                int numDigits = (int)Math.Floor(Math.Log10(number) + 1);
                int[] digitsArray = new int[numDigits];
                for (int i = numDigits - 1; i >= 0; i--)
                {
                    digitsArray[i] = number % 10;
                    number /= 10;
                }
                Console.WriteLine($"число {string.Join(",", digitsArray)}");
            }
        }
    }
}
