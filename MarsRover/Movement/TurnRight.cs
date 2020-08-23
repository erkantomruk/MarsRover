using MarsRover.Models;

namespace MarsRover.Movement
{
    public class TurnRight : ICommand
    {
        private Rover _rover;
        public TurnRight(Rover rover)
        {
            _rover = rover;
        }
        public void Execute()
        {
            _rover.TurnRight();
        }
    }
}
