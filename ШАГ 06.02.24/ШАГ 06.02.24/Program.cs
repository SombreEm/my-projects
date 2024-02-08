using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_06._02._24
{
    public class Figure
    {
        public  double Area { get; }
    }
    public class Square : Figure
    {
        public double Side { get; set; }
        public double Area => Side * Side;
    }
    public class Circle : Figure
    {
        public double Radius { get; set; }
        public double Area => Math.PI * Math.Pow(Radius,2);
    }
    public class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public string Sound
        {
            get { return "ГАФ!"; }
        }
    }

    public class Cat : Animal
    {
        public string Sound
        {
            get { return "МЯУ!"; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square { Side = 200 };
            Circle circle = new Circle { Radius = 13 };

            Console.WriteLine($"Квадрат - {square.Area}");
            Console.WriteLine($"Коло - {circle.Area}");


            Dog myDog = new Dog { Name = "Гріс" };
            Cat myCat = new Cat { Name = "Мурзік" };

            Console.WriteLine($"{myDog.Name} - {myDog.Sound}");
            Console.WriteLine($"{myCat.Name} - {myCat.Sound}");
        }
    }
}
