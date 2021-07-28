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

        //так делать не стоит
        //public Task<T> GetNextValue()
        //{
        //    var task = new Task<T>(() => 
        //    {
        //        onChanged = null;
        //        return _currentValue;
        //    });
        //    onChanged += () => task.Start(); 
        //    return task;
        //}

        public Task<T> GetNextValue()
        {
            var task = new TaskCompletionSource<T>();
            onChanged += () =>
            {
                task.SetResult(_currentValue);
                onChanged = null;
            };
            return task.Task;
        }

    }
}