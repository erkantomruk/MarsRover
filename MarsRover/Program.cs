using MarsRover.Models;
using MarsRover.Movement;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var plateau = new Plateau();

                CommandInvoker commandInvoker = new CommandInvoker();
                foreach (var rover in plateau.Rovers)
                {
                    commandInvoker.AddCommand(rover.Commands.ToArray());
                    commandInvoker.RunCommands();

                    Console.WriteLine(rover);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error has occured.");
            }
            
        }
    }
}
