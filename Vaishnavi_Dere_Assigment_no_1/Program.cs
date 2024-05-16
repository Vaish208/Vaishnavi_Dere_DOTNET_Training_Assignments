using System;
using System.Collections.Generic;

namespace Vaishnavi_Dere_Assignment_no_1
{
    internal class Program
    {
        static Dictionary<int, Task> tasks = new Dictionary<int, Task>();
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
            string title = Console.ReadLine();
            Console.Write("Write the description of your task: ");
            string description = Console.ReadLine();
            tasks.Add(taskId++, new Task { Title = title, Description = description });
            Console.WriteLine("Task created successfully.");
        }

        static void ReadTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task ID: {task.Key}, Title: {task.Value.Title}, Description: {task.Value.Description}");
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

            Console.Write("Do you want to update the title (1) or description (2)?: ");
            bool isChoiceNumber = int.TryParse(Console.ReadLine(), out int choice);

            if (!isChoiceNumber || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            if (choice == 1)
            {
                Console.Write("Enter the new title of the task: ");
                string newTitle = Console.ReadLine();
                tasks[taskNumber].Title = newTitle;
                Console.WriteLine("Task title updated successfully.");
            }
            else if (choice == 2)
            {
                Console.Write("Enter the new description of the task: ");
                string newDescription = Console.ReadLine();
                tasks[taskNumber].Description = newDescription;
                Console.WriteLine("Task description updated successfully.");
            }
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

    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
