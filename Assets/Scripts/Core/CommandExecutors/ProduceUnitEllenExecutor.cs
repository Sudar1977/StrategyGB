using Abstractions;
using UnityEngine;

namespace Core
{
    public class ProduceUnitEllenExecutor : CommandExecutorBase<IProduceUnitEllenCommand>
    {
        [SerializeField] private float _minDistanceUnit=2;
        [SerializeField] private float _maxDistanceUnit=3;
        [SerializeField] private float ShiftForvard = 3.0f;

        private float _coordinate => Random.Range(-_maxDistanceUnit, _maxDistanceUnit);


        private void placeUnit(GameObject Prefab)
        {
            var parentPosition = transform.position;
            float x = _coordinate;
            float y = _coordinate;
            while (x > _minDistanceUnit || y > _minDistanceUnit)
            {
                x = _coordinate;
                y = _coordinate;
            }
            var position = new Vector3(x + parentPosition.x, 0, y + parentPosition.z);// + transform.parent.position;

            Instantiate(Prefab, position + Vector3.forward * ShiftForvard, Quaternion.identity, transform.parent);
        }         

        protected override void ExecuteConcreteCommand(IProduceUnitEllenCommand command)
        {
            if(command.UnitPrefab == null)
            {
                Debug.LogError("No prefab to produce Unit");
                return;
            }
            //Instantiate(command.UnitPrefab, transform.position, Quaternion.identity, transform.parent);
            placeUnit(command.UnitPrefab);
        }
        
    }
}
