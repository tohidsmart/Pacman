using System;
using System.Collections.Generic;
using System.Linq;
using Pacman.Entities;

namespace Pacman.Services
{

    /// <summary>
    /// This class implements Right rotation command of Pacman
    /// </summary>
    public class RotateRight : ICommand
    {
        /// <summary>
        /// This method modifies the location using LinkedList. all the locations are chained in clock-wise format
        /// If current location is West, the next location will be head of of linkedlist
        /// Otherwise get the next node in the linked list
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate)
        {
            LinkedList<Position> positionsList = new LinkedList<Position>(Enum.GetValues(typeof(Position)).Cast<Position>());
            var currentPositionNode = positionsList.Find(coordinate.Position);
            Position currentPosition = currentPositionNode.Value;
            if (currentPosition == Position.West)
            {
                coordinate.Position = positionsList.First.Value;
            }
            else
            {
                coordinate.Position = currentPositionNode.Next.Value;
            }
            return coordinate;


        }
    }
}
