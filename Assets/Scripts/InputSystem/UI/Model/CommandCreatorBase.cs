using Abstractions;
using System;
using UnityEngine;
using Utils;
using Zenject;

namespace InputSystem.UI.Model
{
    public abstract class CommandCreatorBase <T> where T : ICommand
    {
        public void CreateCommand(ICommandExecutor commandExecutor, Action<T> onCreate)
        {
            var classSpecificExecutor = commandExecutor as CommandExecutorBase<T>;
            if(classSpecificExecutor != null)
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

    public class ProduceUnitChopmperCommandCreator : CommandCreatorBase<IProduceUnitChomperCommand>
    {
        [Inject] private AssetContext _context;
        protected override void CreateSpecificCommand(Action<IProduceUnitChomperCommand> onCreate)
        {
            onCreate?.Invoke(_context.Inject(new ProduceUnitChomperCommand()));
        }
    }    
    
    
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetContext _context;
        private Action<IMoveCommand> _onCreate;
        private Vector3Value _currentGroundPosition;
        [Inject]
        private void Init(Vector3Value currentGroundPosition)
        {
            _currentGroundPosition = currentGroundPosition;
            currentGroundPosition.onChanged += HandleGroundPostionCChanged;
        }

        private void HandleGroundPostionCChanged()
        {
            _onCreate?.Invoke(_context.Inject(new MoveUnitCommand(_currentGroundPosition.Value)));
        }
        protected override void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            _onCreate = onCreate;
        }
    }
}