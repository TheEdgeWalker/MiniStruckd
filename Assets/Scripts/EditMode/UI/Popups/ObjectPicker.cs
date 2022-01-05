using System.Collections.Generic;
using EditMode.Commands;
using UnityEngine;

namespace EditMode.UI.Popups
{
    public class ObjectPicker : PopupPanel
    {
        private static readonly Vector3 MidScreenViewportPoint = new Vector3(0.5f, 0.5f, 0f);
        
        [SerializeField] private PrefabContainer prefabContainer;
        [SerializeField] private ObjectPickerItem itemPrefab;
        [SerializeField] private Transform scrollContentTransform;

        private readonly LinkedList<ObjectPickerItem> _allItems = new LinkedList<ObjectPickerItem>();
        private ObjectPickerItem _selectedItem;

        private void Awake()
        {
            InstantiateItems(prefabContainer.Characters);
            InstantiateItems(prefabContainer.Doodads);
        }

        public void Select(ObjectPickerItem selected)
        {
            _selectedItem = selected;

            foreach (var item in _allItems)
            {
                item.Select(item == _selectedItem);
            }
        }

        public void Add()
        {
            if (_selectedItem == null)
                return;

            EditModeManager.Instance.AddObject(_selectedItem.Prefab);
            Close();
        }

        private void InstantiateItems(IEnumerable<PrefabContainer.PrefabInfo> items)
        {
            foreach (var info in items)
            {
                var newItem = Instantiate(itemPrefab, scrollContentTransform);
                newItem.Setup(this, info.name, info.preview, info.prefab);
                _allItems.AddLast(newItem);
            }
        }
    }
}
