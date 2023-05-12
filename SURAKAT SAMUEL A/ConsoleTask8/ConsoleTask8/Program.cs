using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleTask8
{
    public static class Program
    {
        public static readonly string startMessage = "================================================ TODO APPLICATION  ===================================================";
        public static readonly string greetingMessage = "\"Welcome to Task Manager! ";
        public static readonly string userAuthenticationMessage = "1. Register  \n2. Login \n0. Exist ";
        public static readonly string userProfileMessage = " \n1.Add Task\n 2.View Task \n 3.Edit Task \n 4.Delete Task \n 5.Complete Task \n 6.Logout ";
        public static User currentUser;

        static void Main(string[] args)
        {
            List<User> users = new List<User>();


            while (true)
            {
                Console.WriteLine(startMessage);
                Console.WriteLine(greetingMessage);
                Console.WriteLine(userAuthenticationMessage);

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        RegisterUI.Register(users);
                        break;
                    case "2":
                        LoginUI.Login(users, ref currentUser);
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Enter between {1,2,0}.");
                        break;
                }
                Console.WriteLine();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }

        }

    }
}
