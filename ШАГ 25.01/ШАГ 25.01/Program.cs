using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_25._01
{
    internal class Program
    {
        class Student
        {
            public string name { get; set; }
            public string surname { get; set; }
            public int age { get; set; }
            public int[] Grades { get; set; }
        }
        class Programs
        {
            static void Main()
            {
                string[] name = { "Іван", "Марія", "Олександр", "Ольга", "Петро", "Анна", "Віктор", "Юлія", "Максим", "Тетяна", "Сергій", "Наталія", "Дмитро", "Катерина", "Артем", "Оксана", "Василь", "Ірина", "Андрій" };
                string[] surname = { "Іванов", "Петренко", "Сидоренко", "Коваленко", "Коваль", "Сергієнко", "Мельник", "Мороз", "Бондаренко", "Козак", "Шевченко", "Григоренко", "Дубовенко", "Захарченко", "Кузьменко", "Олійник", "Лисенко", "Гончаренко", "Шевцов", "Кривенко" };

                Student[] students = Random(name, surname, 20);
                print(students);
            }

            static Student[] Random(string[] name, string[] surname, int count)
            {
                Random random = new Random();
                Student[] students = new Student[count];

                for (int i = 0; i < count; i++)
                {
                    students[i] = new Student
                    {
                        name = name[random.Next(name.Length)],
                        surname = surname[random.Next(surname.Length)],
                        age = random.Next(1, 101)
                    };
                }

                return students;
            }
            static void print(Student[] students)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    Student student = students[i];
                    if (student.age > 18)
                    {
                        Console.WriteLine($"{student.name} {student.surname} {student.age}");
                    }
                }
            }

        }
    }
}





