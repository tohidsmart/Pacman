using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pacman.Entities;

namespace Pacman.Services
{
    /// <summary>
    /// This class implements Left rotation command of Pacman
    /// </summary>
    public class RotateLeft : ICommand
    {
            /// <summary>
            /// This method modify the locations using LinkedList. all the locations are chained in clock-wise format
            /// If current location is North, the next location will be tail of of linkedlist
            /// Otherwise get the next node in the linked list
            /// </summary>
            /// <param name="coordinate"></param>
            /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate)
        {
            
            LinkedList<Position> positionsList = new LinkedList<Position>(Enum.GetValues(typeof(Position)).Cast<Position>());
            var currentPositionNode = positionsList.Find(coordinate.Position);
            Position currentPosition = currentPositionNode.Value;
            if (currentPosition == Position.North)
            {
                coordinate.Position = positionsList.Last.Value;
            }
            else
            {
                coordinate.Position = currentPositionNode.Previous.Value;
            }
            return coordinate;
            
        }
    }
}
