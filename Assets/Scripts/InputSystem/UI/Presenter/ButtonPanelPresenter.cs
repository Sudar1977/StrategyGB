using Abstractions;
using InputSystem.UI.View;
using InputSystem.UI.Model;

using System.Linq;
using UnityEngine;
using Zenject;

namespace InputSystem.UI.Presenter
{
    public class ButtonPanelPresenter : MonoBehaviour
    {
        [SerializeField] SelectedItem _item;
        [SerializeField] ButtonPanelView _view;

        [Inject] private ButtonPanel _buttonPanel;

        private ISelectableItem _currentSelected;
        // Use this for initialization
        void Start()
        {
            _item.onChanged += SetButtons;
            SetButtons();
            _view.onClick += HandleClick;
        }

        private void SetButtons()
        {
            if(_currentSelected == _item.Value)
            {
                return;
            }

            _currentSelected = _item.Value;
            _view.ClearButtons();
            var commandExecutors = (_currentSelected as Component)?.GetComponentsInParent<ICommandExecutor>().ToList();
            _view.SetButtons(commandExecutors);
        }
        private void HandleClick(ICommandExecutor executor)
        {
            Debug.Log("Click handled wigh executor "+executor.GetType().Name);    
            _buttonPanel.HandleClick(executor);
        }
    }
}