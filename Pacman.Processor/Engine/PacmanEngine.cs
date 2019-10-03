using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pacman.Entities;
using Pacman.Services;

namespace Pacman.Processor
{
    public class PacmanEngine : IEngine
    {
        /// <summary>
        /// This method executes and manoeuvres the pacman based on a list of commands
        /// </summary>
        /// <param name="commands">List of user's commands</param>
        /// <returns></returns>
        public Coordinate Manoeuvre(IList<ICommand> commands)
        {
            //First check if there is no invalid command in the list, otherwise fail and show the exception
            var invalidCommand = commands.FirstOrDefault(command => command.GetType() == typeof(InvalidCommand));
            if (invalidCommand != null)
            {
                return invalidCommand.Execute();
            }

            //It filters the collection to find the first 'Place command'
            var filteredCommands = FilterCommandList(commands);
            if (filteredCommands != null && filteredCommands.Any())
            {
                //It executes the 'Place' command and put the pacman into initial position 
                ICommand placeCommand = filteredCommands.First();
                Coordinate coordinatePoint = placeCommand.Execute();
                filteredCommands.ToList().Remove(placeCommand);
                //All the remaining commands will be executed in order
                foreach (var command in filteredCommands)
                {
                    coordinatePoint = command.Execute(coordinatePoint);
                }
                return coordinatePoint;
            }
            //If no 'PLACE' command found, it will show message'
            throw new InvalidOperationException("No Place command found in sequence");
        }

        /// <summary>
        /// This method displays the Pacman current position in this format : X, Y, Location , e.g  2,3, North 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public string Report(Coordinate coordinate)
        {
            return $"{coordinate.X},{coordinate.Y},{Enum.GetName(typeof(Position), coordinate.Position)}";
        }


        private IEnumerable<ICommand> FilterCommandList(IList<ICommand> commands)
        {
            IEnumerable<ICommand> filteredCommand = commands?.SkipWhile(command => command.GetType() != typeof(Place));
            return filteredCommand;
        }
    }
}


