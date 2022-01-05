using System.Collections.Generic;

namespace EditMode
{
    public class CommandManager
    {
        private readonly int _capacity;
        private readonly LinkedList<ICommand> _commands = new LinkedList<ICommand>();

        public int Count => _commands.Count;

        public CommandManager(int capacity)
        {
            _capacity = capacity;
        }

        public void ApplyAndPush(ICommand command)
        {
            if (_commands.Count >= _capacity)
            {
                _commands.RemoveFirst();
            }
            
            command.Apply();
            _commands.AddLast(command);
        }

        public void UndoAndPop()
        {
            if (_commands.Count <= 0)
                return;
            
            _commands.Last.Value.Rollback();
            _commands.RemoveLast();
        }
    }
}
