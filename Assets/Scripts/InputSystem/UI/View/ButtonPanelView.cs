using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace InputSystem.UI.View
{
    public class ButtonPanelView: MonoBehaviour
    {
        [SerializeField] private Button _produceUnitButton;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _attackButton;

        private Dictionary<Type, Button> _buttons;

        public Action<ICommandExecutor> onClick;

        protected void Start()
        {
            _buttons = new Dictionary<Type, Button>
            {
                { typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton },
                { typeof(CommandExecutorBase<IProduceUnitEllenCommand>), _produceUnitButton },
                { typeof(CommandExecutorBase<IProduceUnitChomperCommand>), _produceUnitButton },
                { typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
                { typeof(CommandExecutorBase<IAttackCommand>), _attackButton }
                
            };
            ClearButtons();
        }

        public void SetButtons(List<ICommandExecutor> commandExecutors)
        {
            if (commandExecutors == null)
            {
                return;
            }
            foreach(var executor in commandExecutors)
            {
                var button = _buttons
                              .FirstOrDefault( kvp => kvp.Key.IsInstanceOfType(executor))
                              .Value;
                if (button != null)
                {
                    button.gameObject.SetActive(true);
                    button.onClick.AddListener(() => onClick?.Invoke(executor));
                }
                else
                {
                    Debug.LogError("No button found for executor type " + executor.GetType());
                }
  
            }
        }

        public void ClearButtons()
        {
            foreach(var kvp in _buttons)
            {
                kvp.Value.gameObject.SetActive(false);
                kvp.Value.onClick.RemoveAllListeners();
            }
        }


    }
}