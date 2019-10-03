using System;
using Pacman.Entities;

namespace Pacman.Services
{
    /// <summary>
    /// This class represents  implementation and response when an invalid command is executed.
    /// </summary>
    public class InvalidCommand : ICommand
    {
        public string DetailedMessage { get; set; }
        public Exception InnerException { get; set; }

        public InvalidCommand(string message, Exception exception)
        {
            DetailedMessage = message;
            InnerException = exception;
        }

        public Coordinate Execute(Coordinate coordinate = null)
        {
            throw new InvalidOperationException($"The specified command or list of commands are invalid.\nDetailed: {DetailedMessage} \n {InnerException?.Message}");
        }
    }
}
