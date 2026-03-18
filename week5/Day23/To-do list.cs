using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void AddTask(List<string> tasks)
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();

            if (string.IsNullOrEmpty(task))
            {
                Console.WriteLine("Task cannot be empty.");
            }
            else
            {
                tasks.Add(task);
                Console.WriteLine("Task added!");
            }
        }

        static void ViewTasks(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
            }
            else
            {
                Console.WriteLine("Tasks:");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }

        static void RemoveTask(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
                return;
            }

            Console.Write("Enter task number to remove: ");
            int taskNumber;

            if (int.TryParse(Console.ReadLine(), out taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    string removedTask = tasks[taskNumber - 1];
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Removed: " + removedTask);
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void Main()
        {
            List<string> tasks = new List<string>();
            int choice;

            do
            {
                Console.WriteLine("To-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddTask(tasks);
                        break;

                    case 2:
                        ViewTasks(tasks);
                        break;

                    case 3:
                        RemoveTask(tasks);
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();

            } while (choice != 4);

            Console.ReadLine();
        }
    }
}