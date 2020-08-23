using System;

namespace MarsRover.Exceptions
{
    public class OutOfAreaException : Exception
    {
        public OutOfAreaException()
        {

        }

        public OutOfAreaException(int X, int Y)
        {
            Console.WriteLine($"Error: Point X: {X}, Y: {Y} is out of area.");
        }
    }
}
