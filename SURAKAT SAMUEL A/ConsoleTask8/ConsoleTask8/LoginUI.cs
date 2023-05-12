using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTask8
{
    public  class LoginUI
    {
        public static readonly string userAuthenticationMessage = "1. Register  \n2. Login \n0. Exist ";
        public static readonly string userProfileMessage = "\n1.Add Task\n 2.View Task \n 3.Edit Task \n 4.Delete Task \n 5.Complete Task \n 6.Logout ";

        public static void Login(List<User> users, ref User currentUser)
        {
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            while (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                Console.WriteLine("Invalid email format. Please try again.");
                Console.WriteLine("Enter email:");
                email = Console.ReadLine();
            }

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password format. Password must be 8 characters, uppercase letter, lowercase letter, digit, and special character.");
                Console.ResetColor();
                password = Console.ReadLine();
            }

            User user = users.FirstOrDefault(s => s.Email == email);

            if (user == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not Found");
                Console.ResetColor();
                return;
            }

            if (user.Password != password)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email or Password");
                Console.ResetColor();
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Login successful. Welcome, {user.Name.ToUpper()}!");
            Console.ResetColor();


                List<Task> tasks = new List<Task>();
            currentUser = user;

            if (currentUser != null)
            {

                while (true)
                {
                    Console.WriteLine(userProfileMessage);
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    if (int.TryParse(choice, out int userProfile) && userProfile >= 1 && userProfile <= 6)
                    {
                        switch (userProfile)
                        {
                            case 1:
                                TasksValidation.AddTask(tasks);
                                break;
                            case 2:
                                TasksValidation.viewTask(tasks);
                                break;
                            case 3:
                                TasksValidation.EditTask(tasks);
                                break;
                            case 4:
                                TasksValidation.DeleteTask(tasks);
                                break;
                            case 5:
                                TasksValidation.CompleteTask(tasks);
                                break;
                            case 6:
                                Console.WriteLine("Logout...");
                                currentUser = null;
                                return;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice. Try again.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid response. Please enter a number between 1 and 6.");
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                }
            }
        }




    }
}
