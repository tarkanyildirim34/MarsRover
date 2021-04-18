using MarsRover.Entities;
using System.Collections.Generic;

namespace MarsRover.Business
{
    public interface IRoverManager
    {
        Rover TurnLeft(string roverLocation);
        Rover TurnRight(string roverLocation);
        Rover Move(string roverLocation, string plateauCoordinate);
        string GetRoverLocationString(Rover rover);
        string GetPlateauCoordinateString(Plateau plateau);
        IEnumerable<Rover> CommandRovers(List<RoverMovement> roversMovement);
  
    }
}
