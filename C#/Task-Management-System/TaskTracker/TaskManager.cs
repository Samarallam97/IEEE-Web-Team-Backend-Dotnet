using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private const string dataFilePath = "tasks.txt";

        ///////////////////////////////////////////////////////

        public void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Add Your Task :");
            ////////////////////////////////////////////////
            string description = UpdateDescription();
            ////////////////////////////////////////////////
            Category category = UpdateCategory();
            ////////////////////////////////////////////////
            DateTime? dueDate = UpdateDateTime();
            ////////////////////////////////////////////////
            PriorityLevel priority = UpdatePriority();

            ////////////////////////////////////////////////
            Task task = new Task(description,category,dueDate,priority);
            tasks.Add(task);
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
            Console.WriteLine("Task added successfully.");
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
        }
        private void ViewTasks(List<Task> tasksToView)
        {
            if (tasksToView.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("Index | Description | Category | Due Date | Priority | Status");
                Console.WriteLine("---------------------------------------------------------------");
                for (int i = 0; i < tasksToView.Count; i++)
                {
                    Console.WriteLine($"{i,-5} | {tasksToView[i].Description,-11} | {tasksToView[i].Category,-7} | {tasksToView[i].DueDate?.ToString("MM/dd/yyyy") ?? "N/A",-7} | {tasksToView[i].Priority,-8} | {tasksToView[i].IsCompleted,-6}");
                }
            }      
    }
        public void ViewAllTasks()
            {
                Console.Clear();
                Console.WriteLine("All Tasks:");
                ViewTasks(tasks);
            }

        ///////////////////////////////////////////////////////

        public void ViewIncompleteTasks()
        {
            Console.Clear();
            Console.WriteLine("Incomplete Tasks:");
            // filter & lamda expression
            ViewTasks(tasks.Where(t => !t.IsCompleted).ToList());
        }
        public void ViewCompletedTasks()
        {
            Console.Clear();
            Console.WriteLine("Completed Tasks:");
            ViewTasks(tasks.Where(t => t.IsCompleted).ToList());
        }
        public void SearchTasks()
        {
            Console.Clear();
            Console.WriteLine("Search Tasks");
            Console.Write("Enter search keyword: ");
            string keyword = Console.ReadLine().ToLower();

            List<Task> foundTasks = tasks.Where(t => t.Description.ToLower().Contains(keyword)) .ToList();

            if (foundTasks.Count == 0)
            {
                Console.WriteLine("No tasks found matching the search criteria.");
            }
            else
            {
                Console.WriteLine("Matching Tasks:");
                ViewTasks(foundTasks);
            }
        }

        ///////////////////////////////////////////////////////

        //responsible for loading tasks from a data file and populating a collection (tasks) with the loaded data.
        public void LoadTasks()
        {
            if (File.Exists(dataFilePath))
            {
                string[] lines = File.ReadAllLines(dataFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        Task task = new Task(parts[0], (Category)int.Parse(parts[1]), DateTime.Parse(parts[2]), (PriorityLevel)int.Parse(parts[3]), bool.Parse(parts[4]));
                        tasks.Add(task);
                    }
                }
                Console.WriteLine("Tasks loaded successfully.");
            }
            else
            {
                Console.WriteLine("No previous tasks found.");
            }
        }

        //responsible for saving the tasks from the tasks collection to a data file.
        public void SaveTasks()
        {
            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {
                foreach (Task task in tasks)
                {
                    writer.WriteLine($"{task.Description}|{task.Category}|{task.DueDate}|{(int)task.Priority}|{task.IsCompleted}");
                }
                Console.WriteLine("Tasks saved successfully.");
            }
        }

        ///////////////////////////////////////////////////////
        public void SortTasksByDescription()
        {
            tasks.Sort((x, y) => string.Compare(x.Description, y.Description));
            Console.WriteLine("Tasks sorted by description.");
        }

        public void SortTasksByCompletionStatus()
        {
            tasks.Sort((x, y) => x.IsCompleted.CompareTo(y.IsCompleted));
            Console.WriteLine("Tasks sorted by completion status.");
        }

        ///////////////////////////////////////////////////////
        public void DoProcesure(Action<int> fnPtr, Action print)
        {
            Console.Clear();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            print.Invoke();

            ViewTasks(tasks);

            Console.Write("Enter task index: ");
            int index;

            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid index. Please try again.");
            }

            fnPtr.Invoke(index);
        }

        public void MarkTaskComplete(int index)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
            Console.WriteLine("Task marked as complete.");
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
        }
        public void Remove(int index)
        {
            tasks.Remove(tasks[index]);
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
            Console.WriteLine("Task Removed Successfully !");
            Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
        }

        //////////////////////////////////////////////////////
        public void Update(int index)
        {
            string choice = Console.ReadLine();

            Console.WriteLine("Enter the updated value");


            switch (choice)
            {
                case "1":
                case "Description":
                    tasks[index].Description = UpdateDescription();
                    Console.WriteLine("Task Updated Successfully !");
                    Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
                    break;

                case "2":
                case "Category":
                    tasks[index].Category = UpdateCategory();
                    Console.WriteLine("Task Updated Successfully !");
                    Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
                    break;
                case "3":
                case "DueDate":
                    tasks[index].DueDate = UpdateDateTime();
                    Console.WriteLine("Task Updated Successfully !");
                    Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
                    break;
                case "4":
                case "Priority":
                    tasks[index].Priority = UpdatePriority();
                    Console.WriteLine("Task Updated Successfully !");
                    Console.WriteLine("♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }



        }

        private string UpdateDescription()
        {

            Console.Write("Enter task description | ");
            string description = Console.ReadLine();

            while (description == null || description == "")
            {
                Console.Write("Don't leave this field empty ..");
                Console.Write("Enter task description | ");
                description = Console.ReadLine();
            }

            return description;
        }

        private Category UpdateCategory()
        {
            Console.Write("Choose task category || 1. EDUCATION   2. HEALTH   3. FINANCE   4. PRODUCTIVITY | ");
            Category category;
            while (!Enum.TryParse(Console.ReadLine(), out category) || (int)category < 1 || (int)category > 4)
            {

                Console.Write("Invalid choice.. ");
                Console.Write("Choose task category || 1. EDUCATION   2. HEALTH   3. FINANCE   4. PRODUCTIVITY | ");
            }

            return category;
        }

        private DateTime? UpdateDateTime()
        {

            Console.Write("Enter task due date in the form of MM/dd/yyyy HH:mm:ss AM (optional) | ");
            DateTime? dueDate = null; // nullable value type

            if (DateTime.TryParse(Console.ReadLine(), out DateTime tempDueDate))
            {
                dueDate = tempDueDate;
            }

            return dueDate;
        }

        private PriorityLevel UpdatePriority()
        {
            PriorityLevel priority;
            Console.Write("Choose task priority || 1. Low, 2. Medium, 3. High  | ");
            while (!Enum.TryParse(Console.ReadLine(), out priority) || (int)priority < 1 || (int)priority > 3)
            {
                Console.Write("Invalid choice.. ");
                Console.Write("Choose task priority || 1. Low, 2. Medium, 3. High  | ");
            }
            return priority;
        }
    }
}
