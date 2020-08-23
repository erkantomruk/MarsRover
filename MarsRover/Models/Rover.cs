using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Extensions;
using MarsRover.Movement;
using System.Collections.Generic;

namespace MarsRover.Models
{
    public class Rover
    {
        public Directions Direction { get; set; }
        public Position Position { get; set; }
        public List<ICommand> Commands { get; set; } = new List<ICommand>();
        public IPlateau Plateau { get; set; }
        public void TurnLeft()
        {
            Direction = Direction.Previous();
        }

        public void TurnRight()
        {
            Direction = Direction.Next();
        }
        public void GoForward()
        {
            switch (this.Direction)
            {
                case Directions.E:
                    Position.X += 1;
                    if (!Plateau.IsValidPoint(Position))
                    {
                        throw new OutOfAreaException(Position.X, Position.Y);
                    }
                    break;

                case Directions.S:
                    Position.Y -= 1;
                    if (!Plateau.IsValidPoint(Position))
                    {
                        throw new OutOfAreaException(Position.X, Position.Y);
                    }
                    break;

                case Directions.N:
                    Position.Y += 1;
                    if (!Plateau.IsValidPoint(Position))
                    {
                        throw new OutOfAreaException(Position.X, Position.Y);
                    }
                    break;

                case Directions.W:
                    Position.X -= 1;
                    if (!Plateau.IsValidPoint(Position))
                    {
                        throw new OutOfAreaException(Position.X, Position.Y);
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
