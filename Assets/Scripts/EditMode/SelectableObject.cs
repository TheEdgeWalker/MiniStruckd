using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace EditMode
{
    public class SelectableObject : MonoBehaviour, IPointerClickHandler, ISelectable
    {
        private Renderer _renderer;
        private Collider _collider;

        private Material[] _originalMaterials;
        private Material[] _selectedMaterials;

        private Action<SelectableObject> _onClickCallback;

        private void Awake()
        {
            _renderer = GetComponentInChildren<Renderer>();
            Assert.IsNotNull(_renderer);

            _collider = GetComponentInChildren<Collider>();
            if (_collider == null)
            {
                _collider = gameObject.AddComponent<CapsuleCollider>();
            }

            _originalMaterials = _renderer.materials;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _onClickCallback?.Invoke(this);
        }

        public void Setup(Material selectedMaterial, Action<SelectableObject> onClickCallback)
        {
            _selectedMaterials = new Material[_originalMaterials.Length];
            
            for (int i = 0; i < _selectedMaterials.Length; ++i)
            {
                _selectedMaterials[i] = selectedMaterial;
            }

            _onClickCallback = onClickCallback;
        }

        public void Select(bool isSelected)
        {
            _renderer.materials = isSelected ? _selectedMaterials : _originalMaterials;
        }
    }
}
