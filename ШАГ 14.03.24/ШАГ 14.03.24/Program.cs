using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_14._03._24
{
    internal class Program
    {
        class Chair
        {
            public int Number { get; set; }
            public string Color { get; set; }
            public string PersonName { get; set; }
        }
        static List<Chair> GenerateChairs()
        {
            List<Chair> chairs = new List<Chair>();
            Random random = new Random();
            for (int i = 1; i <= 100; i++)
            {
                Chair chair = new Chair();
                chair.Number = i;
                string[] colors = { "червоний", "зелений", "синій" };
                chair.Color = colors[random.Next(colors.Length)];
                string[] names = { "Максим", "Іван", "Сергій" };
                chair.PersonName = names[random.Next(names.Length)];

                chairs.Add(chair);
            }
            for (int i = 0; i < chairs.Count - 1; i++)
            {
                if (chairs[i].Color == "червоний" && chairs[i + 1].Color == "зелений")
                {
                    var temp = chairs[i];
                    chairs[i] = chairs[i + 1];
                    chairs[i + 1] = temp;
                }
                if (chairs[i].PersonName == "Максим" && chairs[i + 1].PersonName == "Іван")
                {
                    var temp = chairs[i];
                    chairs[i] = chairs[i + 1];
                    chairs[i + 1] = temp;
                }
            }

            return chairs;
        }
        static void Main(string[] args)
        {
            List<Chair> chairs = GenerateChairs();

            chairs = chairs.OrderBy(c => c.Number).ToList();

            foreach (var chair in chairs)
            {
                Console.WriteLine($"Стілець #{chair.Number}, Колір: {chair.Color}, Людина: {chair.PersonName}");
            }

            Console.ReadLine();
        }
    }
}
