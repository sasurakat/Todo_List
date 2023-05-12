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
        }

    }
}
