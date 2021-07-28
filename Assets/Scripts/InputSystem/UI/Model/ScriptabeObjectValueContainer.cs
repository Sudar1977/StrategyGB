using System;
using System.Threading.Tasks;
using UnityEngine;

namespace InputSystem.UI.Model
{
    public abstract class ScriptabeObjectValueContainer <T> : ScriptableObject
    {

        private T _currentValue;
        public T Value => _currentValue;
        public void SetValue(T item)
        {
            _currentValue = item;
            onChanged?.Invoke();
        }

        public event Action onChanged;

        public Task<T> GetNextValue()
        {
            var task = new Task<T>(() => 
            {
                onChanged = null;
                return _currentValue;
            });
            //task.Start();
            onChanged += () => task.Start(); //висит 51:44

            return task;

        }
    }
}