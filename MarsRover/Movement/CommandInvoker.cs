using System.Collections.Generic;

namespace MarsRover.Movement
{
    public class CommandInvoker
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(params ICommand[] command)
        {
            _commands.AddRange(command);
        }

        public void RunCommands()
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();
            }
            _commands.Clear();
        }
    }
}
