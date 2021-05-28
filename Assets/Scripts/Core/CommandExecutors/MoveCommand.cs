using System.Collections;
using Abstractions;
using UnityEngine;

namespace Core
{
    public class MoveCommand : CommandExecutorBase<IMoveCommand>
    {


        protected override void ExecuteConcreteCommand(IMoveCommand command)
        {
            Debug.Log("MoveCommand");
        }
    }
}