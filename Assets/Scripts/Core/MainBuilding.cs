using Abstractions;
 using UnityEngine;
    
namespace Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitEllenCommand>, ISelectableItem
    {

        [SerializeField] private Sprite _icon;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        [SerializeField] private float _minDistanceUnit=2;
        [SerializeField] private float _maxDistanceUnit=3;

        private float _coordinate => Random.Range(-_maxDistanceUnit, _maxDistanceUnit);
        

        public Sprite Icon => _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;


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

            Instantiate(Prefab, position, Quaternion.identity, transform.parent);
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
