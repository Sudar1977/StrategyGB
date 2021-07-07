using UnityEngine;
using Abstractions;

namespace Core
{
    public class ProduceUnitChomperExecutor : CommandExecutorBase<IProduceUnitChomperCommand>
    {
        [SerializeField] private float ShiftForvard = 3.0f;
        protected override void ExecuteConcreteCommand(IProduceUnitChomperCommand command)
        {
            if (command.UnitPrefab == null)
            {
                Debug.LogError("No prefab to produce Unit");
                return;
            }
            //Instantiate(command.UnitPrefab, transform.position, Quaternion.identity, transform.parent);
            var position = new Vector3(Random.Range(0, 3), 0, Random.Range(0, 2));// + transform.parent.position;

            Instantiate(command.UnitPrefab, position+Vector3.forward*ShiftForvard, Quaternion.identity, transform.parent);
        }
    }
}