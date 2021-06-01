using Abstractions;
using System;
using Utils;
using Zenject;

namespace InputSystem.UI.Model
{
    public abstract class CommandCreatorBase <T> where T : ICommand
    {
        public void CreateCommand(ICommandExecutor commandExecutor, Action<T> onCreate)
        {
            if(commandExecutor as CommandExecutorBase<T>)
            {
                CreateSpecificCommand(onCreate);
            }
        }

        protected abstract void CreateSpecificCommand(Action<T> onCreate);
    }

    public class ProduceUnitElenCommandCreator : CommandCreatorBase<IProduceUnitEllenCommand>
    {
        [Inject] private AssetContext _context;
        protected override void CreateSpecificCommand(Action<IProduceUnitEllenCommand> onCreate)
        {
            onCreate?.Invoke(_context.Inject(new ProduceUnitElenCommand()));
        }
    }

    public class MoveCommand : CommandCreatorBase<IMoveCommand>
    {
        protected override void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            throw new System.NotImplementedException();
        }
    }
}