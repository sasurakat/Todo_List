using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleTask8
{
    public class RegisterUI
    {
        public static void Register(List<User> users)
        {
            Console.WriteLine("Please enter your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your Email:");
            string email = Console.ReadLine();
            while (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                Console.WriteLine("Invalid email format. Please try again.");
                Console.WriteLine("Please enter your email:");
                email = Console.ReadLine();
            }

            ///User Authentication
            Console.WriteLine("Please enter your password:");
            string password1 = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(password1) || !Regex.IsMatch(password1, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"))
            {
                Console.WriteLine("Password must be 8 characters, contain uppercase, lowercase, digit, and special character.");
                password1 = Console.ReadLine();
            }

            Console.WriteLine("Please confirm your password:");
            string password2 = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(password2) || password1 != password2)
            {
                if (string.IsNullOrWhiteSpace(password2))
                {
                    Console.WriteLine("Please enter a valid password.");
                }
                else
                {
                    Console.WriteLine("Passwords do not match. Please try again.");
                }
                password2 = Console.ReadLine();
            }

            User user = new User(name, email, password2);
            users.Add(user);

            Console.WriteLine("Registration successful!");



            if (user == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not Found");
                Console.ResetColor();
                return;
            }

            if (user.Password != password2)
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
            Program.currentUser = user;

            if (Program.currentUser != null)
            {

                while (true)
                {
                    Console.WriteLine(LoginUI.userProfileMessage);
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
                                Program.currentUser = null;
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
                    Console.ResetColor ();
                }
                
            }











        }

    }
}
