using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTask8
{
    public static class TasksValidation
    {
        public static int ItemId { get; private set; }

        public static void AddTask(List<Task> tasks)
            
        {
            
            Console.WriteLine("Title:");
            string titles = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the due date (format: DD-MM-YYYY):");
            string dueDateString = Console.ReadLine();
            DateTime? dueDate = null;

            
            Regex dateFormat = new Regex(@"^\d{2}-\d{2}-\d{4}$");
            if (!dateFormat.IsMatch(dueDateString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter a date in the format \"DD-MM-YYYY\".");
                Console.ResetColor();
            }
            while (true)
            {
                if (!DateTime.TryParseExact(dueDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDueDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date. Please enter a valid date in the format \"DD-MM-YYYY\".");
                    Console.ResetColor();
                    dueDateString = Console.ReadLine();
                }
                else
                {
                    dueDate = parsedDueDate;
                    break;
                }
            }
            Console.Clear();

            Console.WriteLine("Periority Level:");
            string level = Console.ReadLine();
                while (true)
                { 
                    PeriorityLevel periorityLevel;
                    if (!Enum.TryParse(level, true, out periorityLevel))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid");
                        Console.ResetColor();
                        return;
                    }
                    Task task = new Task(ItemId = tasks.Count +1, titles, description, dueDateString, periorityLevel, CurrentUser.Id);
                    tasks.Add(task);
                     Console.Clear();
                     Console.ForegroundColor = ConsoleColor.Green;
                      Console.WriteLine("Task Added successfully");
                         Console.ResetColor();
                      break;
                    
                }
        }

        public static void viewTask(List<Task> tasks)
        {

            Console.WriteLine("All Tasks:");
            List<Task> userTasks = tasks.FindAll(t => t.UserID == CurrentUser.Id);

            if (userTasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No tasks found.");
                return;
            }
            TableUI.PrintTable(userTasks);
                

        }
        public static void DeleteTask(List<Task> tasks)
        {

            if (tasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items.");
                Console.ResetColor();
                return;
            }


            Console.WriteLine("Select to Delete:");
            string title = Console.ReadLine();

            Task taskToDelete = tasks.FirstOrDefault(task => task.Title == title);

            if (taskToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task not found.");
                Console.ResetColor();
                return;
            }

            tasks.Remove(taskToDelete);
            Console.WriteLine("Deleted successfully.");
        }

        public static void EditTask(List<Task> tasks)
        {
            Console.WriteLine("Edit Task");
            Console.WriteLine("Enter the Task Title");
            string title = Console.ReadLine();
            Task taskToEdit = tasks.FirstOrDefault(task => task.Title == title);
            if (taskToEdit == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task not found.");
                Console.ResetColor();
                return;

            }
            Console.WriteLine(" New Title:");
            string newTitle = Console.ReadLine();

            Console.WriteLine(" New Description:");
            string newDescription = Console.ReadLine();

            Console.WriteLine("Input New Due date:");
            string newDueDate = Console.ReadLine();

            Console.WriteLine("New Periority Level:");
            string newLevel = Console.ReadLine();

            PeriorityLevel periorityLevel;
            if (!Enum.TryParse(newLevel, true, out periorityLevel))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid");
                Console.ResetColor();
                return;
            }
            taskToEdit.Title = newTitle;
            taskToEdit.Description = newDescription;
            taskToEdit.Duedate = newDueDate;
            taskToEdit.PeriorityLevel = periorityLevel;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task Updated Successfully");
            Console.ResetColor();
        }

        public static void CompleteTask(List<Task> tasks)
        {
            Console.WriteLine("Complete Task");
            Console.WriteLine("Enter the Task Title:");
            string title = Console.ReadLine();

            Task taskToComplete = tasks.FirstOrDefault(task => task.Title == title);
            if (taskToComplete == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Task not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Is the task completed? (Yes/No): ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "yes")
            {
                taskToComplete.IsCompleted = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task completed successfully.");
                Console.ResetColor();
            }
            else if (input == "no")
            {
                taskToComplete.IsCompleted = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Task status updated to incomplete.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Task status not updated.");
                Console.ResetColor();
            }
            Console.ResetColor();
        }


    }


}

