using Abstractions;
using UnityEngine;

namespace Core
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteConcreteCommand(IAttackCommand command)
        {
            Debug.Log("AttackCommand");
        }
    }
}
