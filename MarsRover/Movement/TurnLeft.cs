using MarsRover.Models;

namespace MarsRover.Movement
{
    public class TurnLeft : ICommand
    {
        private Rover _rover;

        public TurnLeft(Rover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.TurnLeft();
        }
    }
}
