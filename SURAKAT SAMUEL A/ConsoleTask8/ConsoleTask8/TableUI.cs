using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTask8
{
    internal class TableUI
    {
        static readonly int tableWidth = 90;
        public static void DisplayCalHeader()
        {
            
            string headerText = "TODO APPLICATION";

            // Calculate the center position of the header based on the console width
            int headerWidth = headerText.Length + 4;
            int centerPosition = (Console.WindowWidth / 2) - (headerWidth / 2);

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 120));
            Console.WriteLine($"{new string(' ', centerPosition)}|  {headerText}  |");
            Console.WriteLine(new string('=', 120));
            Console.ResetColor();
        }


        public static void PrintTable(List<Task> tasks)
        {
          

            Console.Clear();
            Console.WriteLine(CentreText("TODO_lIST", tableWidth));
            PrintLine();
            PrintRow("ID", "TITLE", "DESCRIPTION", "DUE DATE", "PRIORITY", "COMPLETED");
            PrintLine();
            
            foreach (Task task in tasks)
            {
                int itemId =tasks.IndexOf(task);

                PrintRow(task.ItemId.ToString(), task.Title,
                    task.Description, task.Duedate.ToString(), task.PeriorityLevel.ToString(), task.IsCompleted.ToString());


               
            }
            PrintLine();
            Console.WriteLine("\n \n");

        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }

        static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }
    }
}
