using Pacman.Entities;

namespace Pacman.Services
{
    public class Move : ICommand
    {
        /// <summary>
        /// This class represents implementation of Move command 
        /// It execute the logic based on the current position the Pacman is facing and 
        /// manipulate X,Y coordinates
        /// </summary>
        /// <param name="currentCoordinate">Current position of pacman in [X,Y,Location] format </param>
        /// <returns></returns>
        public Coordinate Execute(Coordinate currentCoordinate)
        {
            switch (currentCoordinate.Position)
            {
                case Position.North:

                    if (currentCoordinate.Y < Coordinate.MAX_Y)
                    {
                        currentCoordinate.Y++;
                    }
                    break;
                case Position.East:
                    if (currentCoordinate.X < Coordinate.MAX_X)
                    {
                        currentCoordinate.X++;
                    }
                    break;
                case Position.South:
                    if (currentCoordinate.Y > Coordinate.Start_Coordinate)
                    {
                        currentCoordinate.Y--;
                    }
                    break;
                case Position.West:
                    if (currentCoordinate.X > Coordinate.Start_Coordinate)
                    {
                        currentCoordinate.X--;
                    }
                    break;
            }
            return currentCoordinate;
        }
    }
}
