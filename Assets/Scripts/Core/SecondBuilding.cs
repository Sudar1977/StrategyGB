using Abstractions;
using UnityEngine;

namespace Core
{
    public class SecondBuilding : CommandExecutorBase<IProduceUnitChomperCommand>, ISelectableItem
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public Sprite Icon => _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        protected override void ExecuteConcreteCommand(IProduceUnitChomperCommand command)
        {
            if (command.UnitPrefab == null)
            {
                Debug.LogError("No prefab to produce Unit");
                return;
            }
            //Instantiate(command.UnitPrefab, transform.position, Quaternion.identity, transform.parent);
            var position = new Vector3(Random.Range(-3, 3), 0, Random.Range(-2, 2));// + transform.parent.position;

            Instantiate(command.UnitPrefab, position, Quaternion.identity, transform.parent);
        }

    }
}