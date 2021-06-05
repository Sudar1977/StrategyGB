using Abstractions;
using UnityEngine;
using Utils;
using Zenject;

namespace InputSystem.UI.Model
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        //[InjectAsset("Ellen")] public GameObject _unitPrefab; //на уроке только так получилось
       [InjectAsset("Ellen")] private GameObject _unitPrefab;
       //[Inject] private GameObject _unit;
        public GameObject UnitPrefab => _unitPrefab;//  { get; }
    }


    public class ProduceUnitElenCommand : IProduceUnitEllenCommand
    {
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

    public class ProduceUnitChomperCommand : IProduceUnitChomperCommand
    {
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

    public class AttackUnitCommand : IAttackCommand
    {

    }

    public class MoveUnitCommand : IMoveCommand
    {
        public Vector3 Position { get; }

        public MoveUnitCommand(Vector3 position)
        {
            Position = position;
        }
        

    }
    public class ProduceUnitCommandHeir : ProduceUnitCommand
    //public class ProduceUnitCommandHeir : ProduceUnitElenCommand
    {

    }


}