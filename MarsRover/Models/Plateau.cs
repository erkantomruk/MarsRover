using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Movement;
using System;
using System.Collections.Generic;

namespace MarsRover.Models
{
    public class Plateau : IPlateau
    {
        private int width;

        public int GetWidth()
        {
            return width;
        }

        public void SetWidth(int value)
        {
            width = value;
        }

        private int height;

        public int GetHeight()
        {
            return height;
        }

        public void SetHeight(int value)
        {
            height = value;
        }

        public List<Rover> Rovers { get; set; } = new List<Rover>();

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Plateau()
        {
            string size = Console.ReadLine();

            SetWidth(int.Parse(size.Split(" ")[0]));
            SetHeight(int.Parse(size.Split(" ")[1]));

            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {

                var position = new Position
                {
                    X = int.Parse(line.Split(" ")[0]),
                    Y = int.Parse(line.Split(" ")[1])
                };

                if (!IsValidPoint(position))
                {
                    throw new OutOfAreaException(position.X, position.Y);
                }

                var rover = new Rover
                {
                    Direction = (Directions)Enum.Parse(typeof(Directions), line.Split(" ")[2]),
                    Position = new Position
                    {
                        X = int.Parse(line.Split(" ")[0]),
                        Y = int.Parse(line.Split(" ")[1])
                    },
                    Plateau = this
                };

                var commands = Console.ReadLine().ToCharArray();
                ParseCommands(rover, commands);

                Rovers.Add(rover);
            }
        }

        public void ParseCommands(Rover rover, char[] commands)
        { 
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        rover.Commands.Add(new TurnLeft(rover));
                        break;
                    case 'R':
                        rover.Commands.Add(new TurnRight(rover));
                        break;
                    case 'M':
                        rover.Commands.Add(new MoveForward(rover));
                        break;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }

        }

        public bool IsValidPoint(Position position)
        {
            return (position.X >= 0 && position.X <= width && position.Y >= 0 && position.Y <= height);
        }
    }
}
