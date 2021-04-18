using MarsRover.Business;
using MarsRover.Core.Enums;
using MarsRover.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.Test
{
    public class MovementTest
    {
        private IRoverManager _roverManager;

        public MovementTest()
        {
            _roverManager = new ServiceCollection().AddSingleton<IRoverManager, RoverManager>().BuildServiceProvider().GetService<IRoverManager>();

        }
         
        [Fact]
        public void MoveForward()
        {
            string roverLocation = "1 2 N";
            string plateauCoordinate = "5 5";
            var rover = _roverManager.Move(roverLocation, plateauCoordinate);
            Assert.Equal(3, rover.YCoordinate);
            Assert.Equal(1, rover.XCoordinate);
        }

        [Fact]
        public void TurnLeft()
        {
            string roverLocation = "1 2 N";

            var rover = _roverManager.TurnLeft(roverLocation);

            Assert.Equal(DirectionType.W, rover.DirectionType);
        }

        [Fact]
        public void TurnRight()
        {

            string roverLocation = "1 2 N";

            var rover = _roverManager.TurnRight(roverLocation);

            Assert.Equal(DirectionType.E, rover.DirectionType);
        }

        [Fact]
        public void Command()
        {

            var rovers = new List<RoverMovement>
            {
                new RoverMovement { PlateauCoordinate="5 5", RoverLocation ="1 2 N",  MovementProcess="LMLMLMLMM" },
                new RoverMovement { PlateauCoordinate="5 5", RoverLocation ="3 3 E",  MovementProcess="MMRMMRMRRM" }
            };
            var result = _roverManager.CommandRovers(rovers).ToList();

            Assert.Equal("1 3 N", $"{result[0].XCoordinate} {result[0].YCoordinate} {result[0].DirectionType}");
            Assert.Equal("5 1 E", $"{result[1].XCoordinate} {result[1].YCoordinate} {result[1].DirectionType}");
        }
    }
}
