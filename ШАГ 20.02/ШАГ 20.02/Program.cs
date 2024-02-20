using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_20._02
{
    internal class Program
    {
        public interface Animal
        {
            void MakeSound();
            void Eat();
        }

        public abstract class Mammal : Animal
        {
            public abstract string FoodType { get; }
            public abstract void MakeSound();
            public abstract void Eat();
        }

        public class Dog : Mammal
        {
            public override string FoodType => "М'ясо";
            public override void MakeSound()
            {
                Console.WriteLine("Гав!");
            }
            public override void Eat()
            {
                Console.WriteLine("Собака їсть м'ясо.");
            }
        }

        public class Cat : Mammal
        {
            public override string FoodType => "М'ясо";
            public override void MakeSound()
            {
                Console.WriteLine("Мяу!");
            }
            public override void Eat()
            {
                Console.WriteLine("Кішка їсть м'ясо.");
            }
        }

        public class Elephant : Mammal
        {
            public override string FoodType => "Рослини";
            public override void MakeSound()
            {
                Console.WriteLine("Трубить!");
            }
            public override void Eat()
            {
                Console.WriteLine("Слон їсть рослини.");
            }
        }

        public class Zoo
        {
            private List<Animal> animals = new List<Animal>();
            public void AddAnimal(Animal animal)
            {
                animals.Add(animal);
            }
            public void PrintAnimals()
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine($"{animal.GetType().Name}:");
                    animal.MakeSound();
                    animal.Eat();
                    Console.WriteLine();
                }
            }
        }

        private static void AddAnimal(Zoo zoo)
        {
            Console.WriteLine("1. Собака");
            Console.WriteLine("2. Кішка");
            Console.WriteLine("3. Слон");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    zoo.AddAnimal(new Dog());
                    break;
                case "2":
                    zoo.AddAnimal(new Cat());
                    break;
                case "3":
                    zoo.AddAnimal(new Elephant());
                    break;
                default:
                    Console.WriteLine("Невідома тварина.");
                    break;
            }
        }

        private static void Main(string[] args)
        {
            var zoo = new Zoo();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Додати тварину");
                Console.WriteLine("2. Переглянути тварин");
                Console.WriteLine("3. Вихід");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddAnimal(zoo);
                        break;
                    case "2":
                        zoo.PrintAnimals();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невідома команда.");
                        break;
                }
            }
        }
    }
}
