using Pacman.Entities;
using Pacman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.Parser
{
    /// <summary>
    /// This is the base class for Command parser
    /// File parser and console parser inherit from this class
    /// </summary>
    public abstract class CommandParser
    {
        private const int POSITION_ELEMENTS = 2;

        /// Each child class needs to implement the this method
        public abstract List<string> GetTextCommands();

        /// <summary>
        /// The Parse method is  same for any child classes , hence the implementation is in parent class
        /// </summary>
        /// <returns></returns>
        public List<ICommand> Parse()
        {
            List<string> commandsInText = GetTextCommands();
            List<ICommand> commandsList = new List<ICommand>();
            foreach (var command in commandsInText)
            {
                commandsList.Add(GetCommand(command));
            }
            return commandsList;
        }

        /// <summary>
        /// This method returns different types of command based on the text 
        /// </summary>
        /// <param name="commandInText"></param>
        /// <returns></returns>
        private ICommand GetCommand(string commandInText)
        {
            if (commandInText.ToUpper().TrimStart().TrimEnd().StartsWith(nameof(Command.PLACE))) return GetPlaceCommand(commandInText.TrimStart().TrimEnd());
            if (commandInText.ToUpper().Trim() == nameof(Command.MOVE)) return new Move();
            if (commandInText.ToUpper().Trim() == nameof(Command.RIGHT)) return new RotateRight();
            if (commandInText.ToUpper().Trim() == nameof(Command.LEFT)) return new RotateLeft();
            return new InvalidCommand($"Command is unrecognized: {commandInText}", null);
        }

        /// <summary>
        /// This method manipulates, validates and and builds the Place command 
        /// </summary>
        /// <param name="commandInText"></param>
        /// <returns></returns>
        private ICommand GetPlaceCommand(string commandInText)
        {
            //it splits the text based on comma, removes the empty etries and get the coordinate part 
            string[] coordinates = commandInText.Split(" ",StringSplitOptions.RemoveEmptyEntries)[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (coordinates.Length >= POSITION_ELEMENTS)
                {
                    int X = Convert.ToInt32(coordinates[0]);
                    int Y = Convert.ToInt32(coordinates[1]);
                    Position position = Enum.Parse<Position>(coordinates[2], true);
                    return new Place(X, Y, position);
                }
                throw new InvalidCastException("Input string is not in correct format");
            }
            catch (Exception exception)
            {
                StringBuilder message = new StringBuilder();
                for (int i = 0; i < coordinates.Length; i++)
                {
                    message.Append($"{coordinates[i]},");
                }
                return new InvalidCommand($"The values of Place command are invalid: {message.ToString()} "
                                         , exception);

            }
        }
    }
}

