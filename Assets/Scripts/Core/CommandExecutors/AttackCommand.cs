using Abstractions;
using UnityEngine;

namespace Core
{
    public class AttackCommand: CommandExecutorBase<IAttackCommand>
    {


        protected override void ExecuteConcreteCommand(IAttackCommand command)
        {
            Debug.Log("AttackCommand");
        }
    }
}
