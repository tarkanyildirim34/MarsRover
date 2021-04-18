using Microsoft.Extensions.DependencyInjection;
using MarsRover.Business;
using MarsRover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        private static IRoverManager _roverManager { get; set; }
        public static void Initialize()
        {
            _roverManager = new ServiceCollection().AddSingleton<IRoverManager, RoverManager>().BuildServiceProvider().GetService<IRoverManager>();
        }
        static void Main(string[] args)
        {
            Initialize();
     

            var rovers = new List<RoverMovement>
            {
                new RoverMovement { PlateauCoordinate="5 5", RoverLocation ="1 2 N",  MovementProcess="LMLMLMLMM" },
                new RoverMovement { PlateauCoordinate="5 5", RoverLocation ="3 3 E",  MovementProcess="MMRMMRMRRM" }
            };

            var result = _roverManager.CommandRovers(rovers).ToList();

            var sb = new StringBuilder();
            for (int i = 0; i < rovers.Count; i++)
            {
                sb.AppendLine("INPUTS: ")
                .Append("Plateau Coordinate: ").Append("\t").AppendLine(rovers[i].PlateauCoordinate)
                .Append("Rover Location: ").Append("\t").AppendLine(rovers[i].RoverLocation)
                .Append("Movement Process: ").Append("\t").AppendLine(rovers[i].MovementProcess)
                .Append("OUTPUT: ").Append("\t\t").AppendLine(_roverManager.GetRoverLocationString(result[i]))
                .AppendLine("------").AppendLine();
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
