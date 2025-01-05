using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker;

namespace TaskTracker
{
    internal class Program
    {
        static void DisplayMainMenu()
        {
            Console.WriteLine
(@"                                                
1. Add Task
2. Mark Task as Complete
3. View All Tasks
4. View Incomplete Tasks
5. View Completed Tasks
6. Sort Tasks by Description
7. Sort Tasks by Completion Status
8. Search Tasks
9. Remove a task
10. Update a task
11. Quit
");
            Console.Write("Enter your choice: ");

        }


        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            taskManager.LoadTasks();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                DisplayMainMenu();
                int choice;
                
                while (!int.TryParse(Console.ReadLine(), out choice) || choice<0 || choice > 11)
                {
                     Console.Write("invalid choice ..Enter your choice: ");
                }
                
                switch (choice)
                {
                    case 1:
                        taskManager.AddTask();
                        break;
                    case 2:
                        taskManager.DoProcesure(taskManager.MarkTaskComplete,()=> Console.WriteLine("Mark a task as complete : "));
                        break;
                    case 3:
                        taskManager.ViewAllTasks();
                        break;
                    case 4:
                        taskManager.ViewIncompleteTasks();
                        break;
                    case 5:
                        taskManager.ViewCompletedTasks();
                        break;
                    case 6:
                        taskManager.SortTasksByDescription();
                        break;
                    case 7:
                        taskManager.SortTasksByCompletionStatus();
                        break;
                    case 8:
                        taskManager.SearchTasks();
                        break;
                    case 9:
                        taskManager.DoProcesure(taskManager.Remove, () => Console.WriteLine("Remove a task : "));
                        break;
                    case 10:
                        taskManager.DoProcesure(taskManager.Update, () => Console.WriteLine("You want to update task 1. Description   2. Category  3. DueDate  4. Priority | "));
                        break;
                    case 11:
                        taskManager.SaveTasks();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); ///The Console.ReadKey() method waits for a key to be pressed on the keyboard and returns the key information. It's commonly used to pause the program execution and wait for user input before continuing

            }
        }
    }
}
