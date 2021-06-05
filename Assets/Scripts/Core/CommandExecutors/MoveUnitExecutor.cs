using System.Collections;
using Abstractions;
using UnityEngine;

namespace Core
{
    public class MoveUnitExecutor : CommandExecutorBase<IMoveCommand>
    {


        protected override void ExecuteConcreteCommand(IMoveCommand command)
        {
            //ToDo сделать плавное перемещение во времени
            transform.position = command.Position;
            Debug.Log("MoveCommand");
        }
    }
}