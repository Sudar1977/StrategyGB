using Abstractions;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedItem", menuName = "Strategy/Selected Item")]
public class SelectedItem : ScriptableObject
{
    private ISelectableItem _currentValue;
    public  ISelectableItem Value  => _currentValue; 
    public void SetValue(ISelectableItem item)
    {
        _currentValue = item;
        onSelected?.Invoke();
    }

    public Action onSelected;
}
