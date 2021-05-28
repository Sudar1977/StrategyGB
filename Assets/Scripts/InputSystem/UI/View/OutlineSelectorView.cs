using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InputSystem.UI.View
{
    public class OutlineSelectorView: MonoBehaviour
    {
        [SerializeField] private Renderer[] _renders;
        [SerializeField] private Material _outlineMaterial;
        [SerializeField] private SpriteRenderer _circle;

        [SerializeField] private bool _isMaterialSelection = true;
        [SerializeField] private bool _isOutlineSelection = true;
        [SerializeField] private bool _isCircleSelection = true;



        private bool _isSelected;

        protected void Start()
        {
            if(_circle!=null)
                _circle.gameObject.SetActive(false);
        }

        void SetMaterialsColor(List <Material> materials,Color color)
        {
            foreach (Material material in materials)
                material.color = color;
        }


        public void SetSelected(bool isSelected)
        {
            if (isSelected == _isSelected)
                return;
            foreach(var meshRend in _renders)
            {
                var materialList = meshRend.materials.ToList();
                if (isSelected)
                {
                    //meshRend.material.color = Color.green;
                    if(_isMaterialSelection)
                        SetMaterialsColor(materialList,Color.green);
                    if(_isOutlineSelection)
                        materialList.Add(_outlineMaterial);
                }
                else
                {
                    //meshRend.material.color = Color.white;
                    if (_isMaterialSelection)
                        SetMaterialsColor(materialList, Color.white);
                    if (_isOutlineSelection)
                        materialList.RemoveAt(materialList.Count - 1);
                }
                meshRend.materials = materialList.ToArray();
            }
            if (_circle != null && _isCircleSelection)
                _circle.gameObject.SetActive(isSelected);
            _isSelected = isSelected;
        }
    }
}