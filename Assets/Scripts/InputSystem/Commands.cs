using Abstractions;
using UnityEngine;
using Utils;

namespace InputSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        //[InjectAsset("Ellen")] public GameObject _unitPrefab; //�� ����� ������ ��� ����������
       [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;//  { get; }
    }


    public class ProduceUnitElenCommand : IProduceUnitEllenCommand
    {
//      [InjectAsset("Ellen")] public GameObject _unitPrefab; //�� ����� ������ ��� ����������
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;//  { get; }
    }

    public class ProduceUnitChomperCommand : IProduceUnitChomperCommand
    {
        //[InjectAsset("Chomper")] public GameObject _unitPrefab; //�� ����� ������ ��� ����������
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