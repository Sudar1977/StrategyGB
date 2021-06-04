using System;
using UnityEngine;

namespace InputSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy/" + nameof(Vector3Value))]
    public class Vector3Value : ScriptableObject
    {
        private Vector3 _currentValue;
        public Vector3 Value => _currentValue;
        public void SetValue(Vector3 value)
        {
            _currentValue = value;
            onSelected?.Invoke();
        }
        public Action onSelected;
    }
}