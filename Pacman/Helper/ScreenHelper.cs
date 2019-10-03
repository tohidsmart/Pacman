using System;

namespace Pacman.Helper
{
    /// <summary>
    /// This static class display the greeting and general instructions when the program loads
    /// </summary>
    public static class ScreenHelper
    {
        public static void Greeting()
        {
            
            Console.Title = "Pacman Simulator";
           
            Console.WriteLine("                    ===================PacMan Simulator==============");
            Console.WriteLine("                    Supproted commands : Place,Right,Left,Move,Report");
            Console.WriteLine("                    Each set of commands should end in report for result" , Console.ForegroundColor = ConsoleColor.DarkYellow);
            Console.ResetColor();
            Console.WriteLine("                    Example like");
            Console.WriteLine("                    Place {x},{y},{position}");
            Console.WriteLine("                    Move");
            Console.WriteLine("                    Right");
            Console.WriteLine("                    Left");
            Console.WriteLine("                    Report");
            Console.WriteLine("                    Minimum and Maximum X & Y coordinates are 0 to 5",Console.ForegroundColor=ConsoleColor.DarkYellow);
            Console.WriteLine("                    Supported positions are : North, West,East,South", Console.ForegroundColor = ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("Enter any command to continue \n", Console.ForegroundColor = ConsoleColor.DarkRed);
            Console.ResetColor();
        }
    }
}
