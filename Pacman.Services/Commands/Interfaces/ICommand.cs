using Pacman.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman.Services
{
    //This interface represents the contract of actions supported by Pacman
    public interface ICommand 
    {
       Coordinate Execute(Coordinate coordinate = null);
    }
}
