using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman.Entities
{
    //This class represents the coordinate object and grid dimensions
    public class Coordinate
    {
        
        public const int MAX_Y = 5;
        public const int MAX_X = 5;
        public const int Start_Coordinate = 0;
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public Position Position { get; set; }
    }
}
