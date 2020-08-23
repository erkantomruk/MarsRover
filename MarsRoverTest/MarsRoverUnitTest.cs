using MarsRover.Exceptions;
using MarsRover.Models;
using MarsRover.Movement;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRoverTest
{
    public class MarsRoverUnitTest
    {
        [Fact]
        public void IsValidPoint_Should_Return_True_When_Point_Is_In_Area()
        {
            //Arrange
            var plateau = new Plateau(5,5);

            //Act
            bool result = plateau.IsValidPoint(new Position { X = 3, Y = 5 });

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidPoint_Should_Return_False_When_Point_Is_Not_In_Area()
        {
            //Arrange
            var plateau = new Plateau(5, 5);

            //Act
            bool result = plateau.IsValidPoint(new Position { X = 6, Y = 5 });

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CommandInvoker_Should_Move_Rover_To_Correct_Position()
        {
            //Arrange
            string commands = "LMLMLMLMM";
            var plateau = new Plateau(5, 5);
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.N,
                Position = new Position
                {
                    X = 1,
                    Y = 2
                },
                Plateau = plateau
            };
            plateau.Rovers.Add(rover);

            plateau.ParseCommands(rover, commands.ToCharArray());

            //Act
            CommandInvoker commandInvoker = new CommandInvoker();
            commandInvoker.AddCommand(rover.Commands.ToArray());
            commandInvoker.RunCommands();

            //Assert
            Assert.Equal(1, rover.Position.X);
            Assert.Equal(3, rover.Position.Y);
            Assert.Equal(MarsRover.Enums.Directions.N, rover.Direction);
        }

        [Fact]
        public void CommandInvoker_Should_Throw_Exception_When_Rover_Is_Not_In_Area()
        {
            //Arrange
            string commands = "MMMMMM";
            var plateau = new Plateau(5, 5);
            var rover = new Rover
            {
                Direction = MarsRover.Enums.Directions.N,
                Position = new Position
                {
                    X = 1,
                    Y = 2
                },
                Plateau = plateau
            };
            plateau.Rovers.Add(rover);

            plateau.ParseCommands(rover, commands.ToCharArray());

            //Act
            CommandInvoker commandInvoker = new CommandInvoker();
            commandInvoker.AddCommand(rover.Commands.ToArray());

            //Assert
            Assert.Throws<OutOfAreaException>(() => commandInvoker.RunCommands());
        }
    }
}
