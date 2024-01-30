using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ШАГ_30._01
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    List<object[]> test1 = new List<object[]> { new object[] { "XXX", 3 },
        //                                                new object[] { "XXXXX", 6 },
        //                                                new object[] { "XXXXXX", 9 } };

        //    List<object[]> test2 = new List<object[]> { new object[] { "XXX", 1 },
        //                                                new object[] { "XXXXXX", 6 },
        //                                                new object[] { "X", 2 },
        //                                                new object[] { "XXXXXX", 8 },
        //                                                new object[] { "X", 3 },
        //                                                new object[] { "XXX", 1 } };

        //    List<object[]> test3 = new List<object[]> { new object[] { "XX", 2 },
        //                                                new object[] { "XXXX", 6 },
        //                                                new object[] { "XXXXX", 4 } };

        //    List<object[]> test4 = new List<object[]> { new object[] { "XX", 2 },
        //                                                new object[] { "XXXX", 6 },
        //                                                new object[] { "XXXXX", 4 } };

        //    Console.WriteLine(Meeting(test1, 4)); // [0, 1, 3]
        //    Console.WriteLine(Meeting(test2, 5)); // [0, 0, 1, 2, 2]
        //    Console.WriteLine(Meeting(test3, 0)); // 'Game On'
        //    Console.WriteLine(Meeting(test4, 4)); // 'Not enough!'
        //}
        //public static dynamic Meeting(List<object[]> rooms, int need)
        //{
        //    if (need == 0)
        //        return "Game On";

        //    List<int> result = new List<int>();
        //    foreach (var room in rooms)
        //    {
        //        string occupants = room[0] as string;
        //        int maxChairs = Convert.ToInt32(room[1]);
        //        int occupiedChairs = occupants.Count(c => c == 'X');
        //        int availableChairs = Math.Max(0, maxChairs - occupiedChairs);

        //        if (availableChairs >= need)
        //        {
        //            result.Add(need);
        //            return result.ToArray();
        //        }
        //        else if (availableChairs > 0)
        //        {
        //            result.Add(availableChairs);
        //            need -= availableChairs;
        //        }
        //    }

        //    return "Not enough!";
        //}

        class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Deadline { get; set; }
            public bool IsCompleted { get; set; }
            public List<TaskItem> SubTasks { get; set; }

            public TaskItem(string title, string description, DateTime deadline)
            {
                Title = title;
                Description = description;
                Deadline = deadline;
                IsCompleted = false;
                SubTasks = new List<TaskItem>();
            }
        }
        static void Main(string[] args)
        {

        }
    }
}