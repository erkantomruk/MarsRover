using MarsRover.Movement;

namespace MarsRover.Models
{
    public class MoveForward : ICommand
    {
        private Rover _rover;

        public MoveForward(Rover rover)
        {
            this._rover = rover;
        }

        public void Execute()
        {
            _rover.GoForward();
        }
    }
}
