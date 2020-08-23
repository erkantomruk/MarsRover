using Xunit;
using MarsRover.Models;
using MarsRover.Exceptions;

namespace MarsRoverTest
{
    public class RoverUnitTest
    {
        [Fact]
        public void TurnRight_Should_Rotate_Rover_Clockwise()
        {
            //Assert
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.N
            };

            //Act
            rover.TurnRight();

            //Assert
            Assert.Equal(MarsRover.Enums.Directions.E, rover.Direction);
        }

        [Fact]
        public void TurnLeft_Should_Rotate_Rover_AntiClockwise()
        {
            //Assert
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.N
            };

            //Act
            rover.TurnLeft();

            //Assert
            Assert.Equal(MarsRover.Enums.Directions.W, rover.Direction);
        }

        [Fact]
        public void GoForward_Should_Change_Position_Of_Rover_When_It_Is_On_Area()
        {
            //Assert
            var plateau = new Plateau(5, 5);
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.E,
                Position = new Position
                {
                    X = 1,
                    Y = 2
                },
                Plateau = plateau
            };
            plateau.Rovers.Add(rover);

            //Act
            rover.GoForward();

            //Assert
            Assert.Equal(2, rover.Position.X);
            Assert.Equal(2, rover.Position.Y);
        }

        [Fact]
        public void GoForward__Should_Throw_Exception_When_Rover_Is_Not_In_Area()
        {
            //Assert
            var plateau = new Plateau(5, 5);
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.E,
                Position = new Position
                {
                    X = 5,
                    Y = 2
                },
                Plateau = plateau
            };
            plateau.Rovers.Add(rover);

            //Assert
            Assert.Throws<OutOfAreaException>(() => rover.GoForward());
        }
    }
}
