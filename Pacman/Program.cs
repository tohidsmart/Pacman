using Pacman.Entities;
using Pacman.Helper;
using Pacman.Parser;
using Pacman.Processor;
using Pacman.Services;
using System;
using System.Collections.Generic;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            //This line shows the general instructions to user 
            ScreenHelper.Greeting();
            string line = Console.ReadLine();
            //Until the user closes the console,program reads input and geenrates result 
            while (true)
            {
                Operate(line);
                line = Console.ReadLine();
            }
        }

        /// <summary>
        /// This method reads a line from screen and pass it to engine to process
        /// </summary>
        /// <param name="line"></param>
        private static void Operate(string line)
        {

            List<string> commandsInText = new List<string>();
            IEngine engine = new PacmanEngine();
            List<ICommand> commands = new List<ICommand>();

            //Until a report command is not invoked, cursor reads command and adds it to the collection
            while (line.ToUpper() != nameof(Command.REPORT))
            {
                commandsInText.Add(line);
                line = Console.ReadLine();
            }
            //commands collection is passed to parser 
            CommandParser commandParser = new ConsoleKeyParser(commandsInText);
            commands.AddRange(commandParser.Parse());

            try
            {
                //Engine performs the manoeuvre and report the final position of Pacman
                Coordinate lastPosition = engine.Manoeuvre(commands);
                Console.WriteLine();
                Console.WriteLine($"Position report: {engine.Report(lastPosition)}", Console.ForegroundColor = ConsoleColor.Green);
                Console.WriteLine();
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                //If an exception occures in the process, it is displayed in the console and user can start over  
                Console.WriteLine($"Error :{ex.Message}", Console.ForegroundColor = ConsoleColor.Red);
                Console.WriteLine();
                Console.WriteLine(ex.InnerException);
                Console.ResetColor();
            }
        }
    }
}
