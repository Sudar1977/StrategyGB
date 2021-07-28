using Abstractions;
using System;
using UnityEngine;
using Utils;
using Zenject;

namespace InputSystem.UI.Model
{
    public abstract class CommandCreatorBase<T> where T : ICommand
    {
        public void CreateCommand(ICommandExecutor commandExecutor, Action<T> onCreate)
        {
            var classSpecificExecutor = commandExecutor as CommandExecutorBase<T>;
            if (classSpecificExecutor != null)
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
        [Inject] private Vector3Value _currentGroundPosition;
        
        protected  override async void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            var nextClick = await _currentGroundPosition.GetNextValue();
            onCreate?.Invoke(_context.Inject(new MoveUnitCommand(nextClick)));
        }
    }

    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetContext _context;
        protected override void CreateSpecificCommand(Action<IAttackCommand> onCreate)
        {
            onCreate?.Invoke(_context.Inject(new AttackUnitCommand()));
        }
    }
}