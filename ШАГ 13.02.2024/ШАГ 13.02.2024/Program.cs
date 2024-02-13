using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_13._02._2024
{
    public static class Algoritms
    {
        public static dynamic OpenArr(List<object> arr, int pos = 0, List<object> rezult = null)
        {
            if (rezult == null)
            {
                rezult = new List<object>();
            }

            if (arr[pos] is int)
            {
                rezult.Add(arr[pos++]);
                return OpenArr(arr, pos, rezult);
            }

            if (arr[pos] is List<object>)
            {
                List<object> list = (List<object>)arr[pos];
                Console.WriteLine("Enter in new arr");
                return OpenArr(list, pos = 0, rezult);
            }

            return rezult;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> myArr = new List<object>
{
            6,
            44,
            23,
            new List<object>
            {
            53,
            new List<object>
            {
                22,
                32,
                67
            },
                12,
            new List<object>
            {
                4,
                6,
                2
            }
            }

        };

            List<object> result = Algoritms.OpenArr(myArr);

            foreach (object item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
