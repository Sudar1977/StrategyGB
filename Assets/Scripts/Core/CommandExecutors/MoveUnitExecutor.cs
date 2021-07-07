using System.Collections;
using Abstractions;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class MoveUnitExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] NavMeshAgent _agent;

        protected override void ExecuteConcreteCommand(IMoveCommand command)
        {
            _agent.SetDestination(command.Position);
            Debug.Log("MoveCommand");
        }
    }
}