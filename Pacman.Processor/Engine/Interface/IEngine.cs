using Pacman.Entities;
using Pacman.Services;
using System.Collections.Generic;

namespace Pacman.Processor
{
    public interface IEngine
    {
        Coordinate Manoeuvre(IList<ICommand> commands);
        string Report(Coordinate coordinate);
    }
}
