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
//      [InjectAsset("Ellen")] public GameObject _unitPrefab; //на уроке только так получилось
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;//  { get; }
    }

    public class ProduceUnitChomperCommand : IProduceUnitChomperCommand
    {
        //[InjectAsset("Chomper")] public GameObject _unitPrefab; //не уроке только так получилось
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;//  { get; }
    }

    public class AttackUnitCommand : IAttackCommand
    {

    }

    public class MoveUnitCommand : IMoveCommand
    {

    }
    public class ProduceUnitCommandHeir : ProduceUnitCommand
    {

    }


}