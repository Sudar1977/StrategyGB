using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem.UI.Presenter
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectedItem _currentSelection;

        [SerializeField] private EventSystem _eventSystem;

        // Update is called once per frame
        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                {
                    var selectableItem = hitInfo.collider.GetComponent<ISelectableItem>();
                    //selectableItem?.Select();
                    _currentSelection.SetValue(selectableItem);
                }
                else
                {
                    _currentSelection.SetValue(null);
                }
            }
        }
    }
}
