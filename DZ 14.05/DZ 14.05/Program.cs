using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_14._05
{
    internal class Program
    {
        public class Task
        {
            public string Title { get; set; }
            public DateTime CreationDate { get; private set; }
            public DateTime DueDate { get; set; }
            public bool IsCompleted { get; set; }
            public Task(string title, DateTime dueDate)
            {
                Title = title;
                CreationDate = DateTime.Now;
                DueDate = dueDate;
                IsCompleted = false;
            }
            public override string ToString()
            {
                return $"Title: {Title}, Due: {DueDate.ToShortDateString()}, Status: {(IsCompleted ? "Completed" : "Not Completed")}";
            }
            public class Controller
            {
                private List<Task> tasks;
                public Controller()
                {
                    tasks = new List<Task>();
                }
                public void AddTask(string title, DateTime dueDate)
                {
                    tasks.Add(new Task(title, dueDate));
                    Console.WriteLine("Task added successfully.");
                }
                public void CompleteTask(string title)
                {
                    var task = tasks.FirstOrDefault(t => t.Title == title);
                    if (task != null)
                    {
                        task.IsCompleted = true;
                        Console.WriteLine("Task marked as completed.");
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                }
                public void DeleteTask(string title)
                {
                    var task = tasks.FirstOrDefault(t => t.Title == title);
                    if (task != null)
                    {
                        tasks.Remove(task);
                        Console.WriteLine("Task deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Task not found.");
                    }
                }
                public void ViewTasks()
                {
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks available.");
                        return;
                    }

                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task);
                    }
                }
            }
            static void Main(string[] args)
            {
                Controller controller = new Controller();
                string command;

                do
                {
                    Console.WriteLine("\nPlease enter a command: View, Add, Complete, Delete, or Exit");
                    command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "view":
                            controller.ViewTasks();
                            break;

                        case "add":
                            Console.Write("Enter the title of the task: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter the due date (yyyy-mm-dd): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                            {
                                controller.AddTask(title, dueDate);
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format.");
                            }
                            break;

                        case "complete":
                            Console.Write("Enter the title of the task to mark as completed: ");
                            title = Console.ReadLine();
                            controller.CompleteTask(title);
                            break;

                        case "delete":
                            Console.Write("Enter the title of the task to delete: ");
                            title = Console.ReadLine();
                            controller.DeleteTask(title);
                            break;

                        case "exit":
                            Console.WriteLine("Exiting the application.");
                            break;

                        default:
                            Console.WriteLine("Invalid command.");
                            break;
                    }
                } while (command != "exit");
            }
        }
    }
}
