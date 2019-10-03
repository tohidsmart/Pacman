using System.Collections.Generic;

namespace Pacman.Parser
{
    /// <summary>
    /// This class inherits the CommandParser and get the list of commands
    /// </summary>
    public class ConsoleKeyParser : CommandParser
    {
        
        public List<string> Commands { get;  }
        public ConsoleKeyParser(List<string> commands)
        {
            Commands = commands;
        }
        public override List<string> GetTextCommands()
        {
            return Commands;
        }

    }
}
