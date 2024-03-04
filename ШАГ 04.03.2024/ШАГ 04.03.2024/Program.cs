using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_04._03._2024
{
    internal class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
       public class Calculator<T>
        {
            public T add(T a, T b)
            {
                dynamic first = a;
                dynamic second = b;
                return first + second;
            }

            public T subtract(T a, T b)
            {
                dynamic first = a;
                dynamic operand2 = b;
                return first - operand2;
            }

            public T multiply(T a, T b)
            {
                dynamic first = a;
                dynamic operand2 = b;
                return first * operand2;
            }

            public T divide(T a, T b)
            {
                dynamic first = a;
                dynamic operand2 = b;

                if (operand2 == 0)
                {
                    return default(T);
                }

                return first / operand2;
            }
        }
        static void Main(string[] args)
        {
            int a = 5, b = 10;
            Console.WriteLine($"{a} {b}");
            Swap(ref a, ref b);
            Calculator<int> Calculator = new Calculator<int>();
            Console.WriteLine($"{a} {b}");
            Console.WriteLine($"{Calculator.add(4, 3)}");
            Console.WriteLine($"{Calculator.subtract(4, 3)}");
            Console.WriteLine($"{Calculator.multiply(4, 3)}");
            Console.WriteLine($"{Calculator.divide(4, 3)}");
        }
    }
}
