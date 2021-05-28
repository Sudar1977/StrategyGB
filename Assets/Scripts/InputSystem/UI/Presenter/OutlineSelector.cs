using Abstractions;
using InputSystem.UI.View;
using UnityEngine;

namespace InputSystem.UI.Presenter
{
    public class OutlineSelector : MonoBehaviour
    {
        [SerializeField] SelectedItem _currentSelection;
        private ISelectableItem _currentSelected;

        // Use this for initialization
        protected void Start()
        {
            _currentSelection.onSelected += UpdateOutline;
            UpdateOutline();
        }

        private void UpdateOutline()
        {
            if (_currentSelected == _currentSelection.Value)
                return;
            SetSelected(_currentSelected, false);
            _currentSelected = _currentSelection.Value;
            SetSelected(_currentSelected, true );
        }

        private void SetSelected(ISelectableItem view, bool value)
        {
            if(view!=null)
            {
                var outlineView = (view as Component)?.GetComponentInParent<OutlineSelectorView>();
                if (outlineView != null)
                    outlineView.SetSelected(value);
            }
        }


    }
}