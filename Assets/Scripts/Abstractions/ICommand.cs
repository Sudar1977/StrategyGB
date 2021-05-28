using UnityEngine;

namespace Abstractions
{
    public interface ICommand
    {

    }

    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }

    public interface IProduceUnitEllenCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
    public interface IProduceUnitChomperCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }

    public interface IMoveCommand : ICommand
    {
        //Vector3 Position { get; } 
    }

    public interface IAttackCommand : ICommand
    {

    }
}