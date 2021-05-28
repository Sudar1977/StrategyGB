using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace InputSystem.UI.Presenter
{

    public class SelectedItemPresenter : MonoBehaviour
    {
        [SerializeField] protected SelectedItem _item;
        [SerializeField] protected SelectedItemView _view;
        public int tets;

        void reflectionFields()
        { 
        // Get the type handle of a specified class.
            Type myType = typeof(SelectedItemPresenter);

        // Get the fields of the specified class.
            //FieldInfo[] myField = myType.GetFields(BindingFlags.NonPublic);
            FieldInfo[] myField = myType.GetFields();

            Debug.Log("\nDisplaying fields");
            for (int i = 0; i < myField.Length; i++)
            {
                Debug.Log("The field has a Name =" + myField[i].Name);
            }

        }

        protected void Start()
        {
            reflectionFields();
            _item.onSelected += UpdateView;
            UpdateView();
        }

        private void UpdateView()
        {
            var hasItem = _item.Value != null;
            _view.gameObject.SetActive(hasItem);
            if (!hasItem)
            {
                Debug.Log("_item.Value == null");
                return;
            }
            _view.Icon = _item.Value.Icon;
            _view.Text = $"{_item.Value.Health}/{_item.Value.MaxHealth}";
            if (_item.Value.MaxHealth != 0)
                _view.HealthPercent = _item.Value.Health / _item.Value.MaxHealth;
            else
                Debug.LogError("_item.Value.MaxHealth == 0 Division Zero");

        }
    }
}