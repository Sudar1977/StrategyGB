using Abstractions;
using UnityEngine;


namespace InputSystem.UI.Model
{

    [CreateAssetMenu(fileName = "SelectedItem", menuName = "Strategy/Selected Item")]
    public class SelectedItem : ScriptabeObjectValueContainer<ISelectableItem>
    {

    }
}