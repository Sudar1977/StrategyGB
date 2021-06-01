using Abstractions;
using InputSystem.UI.View;
using System.Collections;
using System.Linq;
using UnityEngine;
using Utils;

namespace InputSystem.UI.Presenter
{
    public class ButtonPanelPresenter : MonoBehaviour
    {
        [SerializeField] SelectedItem _item;
        [SerializeField] ButtonPanelView _view;
        [SerializeField] private AssetContext _context;

        private ISelectableItem _currentSelected;
        // Use this for initialization
        void Start()
        {
            _item.onSelected += SetButtons;
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
            //executor.Execute(new Command);
            //TODO разнести создание команд
            if(executor as CommandExecutorBase<IProduceUnitEllenCommand>)
            {
                //executor.Execute(_context.InjectMet(new ProduceUnitElenCommand()));
                executor.Execute(_context.Inject(new ProduceUnitElenCommand()));
            }
            else if(executor as CommandExecutorBase<IProduceUnitChomperCommand>)
            {
                executor.Execute(_context.InjectMet(new ProduceUnitChomperCommand()));
            }
            else if (executor as CommandExecutorBase<IAttackCommand>)
            {
                executor.Execute(_context.Inject(new AttackUnitCommand()));
            }
            else if (executor as CommandExecutorBase<IMoveCommand>)
            {
                executor.Execute(_context.Inject(new MoveUnitCommand()));
            }
            else
            {
                Debug.Log("TODO not handled command");
            }
        }
    }
}