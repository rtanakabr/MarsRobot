using System;
using Tanaka.MarsRobot.HumanTechnology;
using Tanaka.MarsRobot.Universe;

namespace Tanaka.MarsRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plateauWidth;
            int plateauHeight;


            string plateauSize = Console.ReadLine().Replace(" ", "").Trim();
            plateauWidth = int.Parse(plateauSize.Split("x")[0]);
            plateauHeight = int.Parse(plateauSize.Split("x")[1]);
            Planet mars = new Planet(plateauWidth, plateauHeight);

            string movementCommand = Console.ReadLine().Replace(" ", "").Trim();
            Robot marsRover = new Robot(mars, "North");
            marsRover.RunCommand(movementCommand);

            Console.WriteLine(string.Format("{0},{1},{2}", marsRover.PositionX, marsRover.PositionY, marsRover.FacingDirection));

#if(DEBUG)
            Console.ReadKey();
#endif 
        }
    }
}
