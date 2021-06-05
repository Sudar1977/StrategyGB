using Abstractions;
using Zenject;

namespace InputSystem.UI.Model
{
    public class ButtonPanel
    {
        //[Inject] private CommandCreatorBase<IProduceUnitCommand> _produceUnitCommandCreator;
        [Inject] private CommandCreatorBase<IProduceUnitEllenCommand> _produceUnitEllenCommandCreator;
        [Inject] private CommandCreatorBase<IProduceUnitChomperCommand> _produceUnitChomperCommandCreator;
        [Inject] private CommandCreatorBase<IMoveCommand> _moveCommandCreator;
        //[Inject] private CommandCreatorBase<IAttackCommand> _attackCommandCreator;

        private bool _isPending;
        public void HandleClick(ICommandExecutor executor)
        {
            _isPending = true;
            //_produceUnitCommandCreator.CreateCommand(executor, command => ExecuteSpecificCommand(executor,command));
            _produceUnitEllenCommandCreator.CreateCommand(executor, command => ExecuteSpecificCommand(executor, command));
            _produceUnitChomperCommandCreator.CreateCommand(executor, command => ExecuteSpecificCommand(executor, command));
            _moveCommandCreator.CreateCommand(executor, command => ExecuteSpecificCommand(executor, command));
            //_attackCommandCreator.CreateCommand(executor, command => ExecuteSpecificCommand(executor, command));
        }
        private void ExecuteSpecificCommand(ICommandExecutor executor,ICommand command)
        {
            executor.Execute(command);
            _isPending = false;
        }
    }
}