using System.Collections.Generic;
using System.Linq;

namespace Pacman.Parser
{
    /// <summary>
    /// This class inherits from CommandParser and gets the text commands from intput file
    /// This class is used in unit test project to provide data to test methods
    /// </summary>
    public class FileParser : CommandParser
    {
        public string PathToFile { get;  }
        public FileParser(string filePath )
        {
            PathToFile = filePath;
        }

        public override List<string> GetTextCommands()
        {
            return System.IO.File.ReadAllLines(PathToFile).ToList();
        }


    }
}
