using System;
using System.Linq;
using Pacman.Entities;

namespace Pacman.Services
{
    /// <summary>
    /// This class implements the logic for 'Place' command 
    /// 
    /// </summary>
    public class Place : ICommand
    {
        public Coordinate PlacementCoordinate { get; }

        /// <summary>
        /// Constructor initializes the starting point of the Pacman
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="position"></param>
        public Place(int x, int y, Position position)
        {
            PlacementCoordinate = new Coordinate
            {
                X = x,
                Y = y,
                Position = position
            };
        }

        /// <summary>
        /// The method ensures that starting point is valid 
        /// If it is valid, it returns the current position of Pacman to the chain of commands
        /// Otherwise, show the validation error message.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate = null)
        {
            if (!IsValidCoordinate(PlacementCoordinate))
                throw new InvalidOperationException($"Placement coordinates are invalid :{PlacementCoordinate.X},{PlacementCoordinate.Y},{PlacementCoordinate.Position}");
            return PlacementCoordinate;
        }

        /// <summary>
        /// This private method enforces the validation rules on the current objects.
        /// Validation rule such as X should not be greater than 5 
        /// Y should not be greater than 5 
        /// location should be in the list of supported positions { NORTH,EAST, SOUTH,WEST}
        /// </summary>
        /// <param name="placementCoordinate"></param>
        /// <returns></returns>
        private bool IsValidCoordinate(Coordinate placementCoordinate)
        {
            bool isValidX = placementCoordinate.X <= Coordinate.MAX_X && placementCoordinate.X >= Coordinate.Start_Coordinate;
            bool isValidY = placementCoordinate.Y <= Coordinate.MAX_Y && placementCoordinate.Y >= Coordinate.Start_Coordinate;
            bool isValidPosition = Enum.GetNames(typeof(Position)).Contains(Enum.GetName(typeof(Position), placementCoordinate.Position));

            bool isValid = isValidX && isValidY && isValidPosition;
            return isValid;
        }

    }
}
