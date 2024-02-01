using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_01._02_СТО_
{
    internal class Program
    {
        class Box
        {
            public int Id { get; set; }
            public int Workers { get; set; }
            public Box(int id, int workers)
            {
                Id = id;
                Workers = workers;
            }
        }

        class Auto
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public Auto(string brand, string model, int year)
            {
                Brand = brand;
                Model = model;
                Year = year;
            }
        }

        class ServantService
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int BoxId { get; set; }
            public int Duration { get; set; }
            public int Price { get; set; }
            public ServantService(int id, string name, int boxId, int duration, int price)
            {
                Id = id;
                Name = name;
                BoxId = boxId;
                Duration = duration;
                Price = price;
            }
        }
        class AutoService
        {
            private List<Box> boxes;
            private List<Auto> autos;
            private List<ServantService> services;
            private Dictionary<DateTime, List<Box>> schedule;

            public AutoService()
            {
                boxes = new List<Box>();
                autos = new List<Auto>();
                services = new List<ServantService>();
                schedule = new Dictionary<DateTime, List<Box>>();
            }

            public void AddBox(Box box)
            {
                boxes.Add(box);
            }

            public void AddAuto(Auto auto)
            {
                autos.Add(auto);
            }

            public void AddService(ServantService service)
            {
                services.Add(service);
            }

            public DateTime FindFreeDate(Auto auto)
            {
                foreach (DateTime date in schedule.Keys)
                {
                    List<Box> availableBoxes = schedule[date].FindAll(box => CanServiceAuto(box, auto));
                    if (availableBoxes.Count > 0)
                    {
                        return date;
                    }
                }

                DateTime nextAvailableDate = DateTime.Now;
                while (schedule.ContainsKey(nextAvailableDate) || nextAvailableDate.DayOfWeek == DayOfWeek.Saturday || nextAvailableDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    nextAvailableDate = nextAvailableDate.AddHours(1);
                }

                return nextAvailableDate;
            }

            private bool CanServiceAuto(Box box, Auto auto)
            {
                return autos.Contains(auto) && box.Workers >= services.Count(service => service.BoxId == box.Id);
            }
        }

        static void Main(string[] args)
        {
            AutoService autoService = new AutoService();

            autoService.AddBox(new Box(1, 1));
            autoService.AddBox(new Box(2, 1));
            autoService.AddBox(new Box(3, 2));
            autoService.AddBox(new Box(4, 1));

            autoService.AddService(new ServantService(1, "Починка двигуна", 2, 2, 100));
            autoService.AddService(new ServantService(2, "Переобувка машини", 1, 1, 50)); 
            autoService.AddService(new ServantService(3, "Переробка коробки", 3, 3, 120)); 
            autoService.AddService(new ServantService(4, "Заміна масла в двигуні", 1, 1, 60));
            autoService.AddService(new ServantService(5, "Заміна масла в коробці", 1, 1, 40));
            autoService.AddService(new ServantService(6, "Покраска одного елемента", 4, 4, 80));

            Console.Write("Введіть марку авто: ");
            string brand = Console.ReadLine();
            Console.Write("Введіть модель авто: ");
            string model = Console.ReadLine();
            Console.Write("Введіть рік авто: ");
            int year = int.Parse(Console.ReadLine());
            Auto userAuto = new Auto(brand, model, year);
            DateTime freeDate = autoService.FindFreeDate(userAuto);
            Console.WriteLine($"Ваше авто може бути обслуговане {freeDate}");
        }
    }
}

