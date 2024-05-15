using System;
using System.Collections.Generic;

namespace Vaishnavi_Dere_Assignment_no_1
{
    internal class Program
    {
        static Dictionary<int, string> tasks = new Dictionary<int, string>();
        static int taskId = 1;

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Read tasks");
                Console.WriteLine("3. Update a task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit");

                Console.Write("Please Enter your choice: ");
                bool isNumber = int.TryParse(Console.ReadLine(), out int option);

                if (!isNumber)
                {
                    Console.WriteLine("Invalid input. Please enter a number from above list.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        CreateTask();
                        break;
                    case 2:
                        ReadTasks();
                        break;
                    case 3:
                        UpdateTask();
                        break;
                    case 4:
                        DeleteTask();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application.");
                        Console.WriteLine("Project By Vaishnavi Dere - Nashik");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateTask()
        {
            Console.Write("Write the title of your task: ");
            string task = Console.ReadLine();
            tasks.Add(taskId++, task);
            Console.WriteLine("successful.");
        }

        static void ReadTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task ID: {task.Key}, Title: {task.Value}");
            }
        }

        static void UpdateTask()
        {
            Console.Write("Enter the ID of the task you want to update: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int taskNumber);

            if (!isNumber || !tasks.ContainsKey(taskNumber))
            {
                Console.WriteLine("Invalid task ID.");
                return;
            }

            Console.Write("Enter the new title of the task: ");
            string newTask = Console.ReadLine();
            tasks[taskNumber] = newTask;
            Console.WriteLine("Task ID updated successfully.");
        }

        static void DeleteTask()
        {
            Console.Write("Please Enter the ID of the task you want to delete: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int taskNumber);

            if (!isNumber || !tasks.ContainsKey(taskNumber))
            {
                Console.WriteLine("You Entered Invalid task ID.");
                return;
            }

            tasks.Remove(taskNumber);
            Console.WriteLine("Your Task deleted successfully.");
        }
    }
}
