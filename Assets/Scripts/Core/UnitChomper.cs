using Abstractions;
using UnityEngine;

namespace Core
{
    public class UnitChomper : MonoBehaviour, ISelectableItem
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _health = 100;
        [SerializeField] private float _maxHealth = 100;

        public Sprite Icon => _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;

    }
}