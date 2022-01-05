using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace EditMode.UI.Popups
{
    public class PopupManager : MonoBehaviour
    {
        [Serializable]
        private class PopupPrefab
        {
            public string id;
            public PopupPanel prefab;
        }

        [SerializeField] private PopupPrefab[] popupPrefabs;
        [SerializeField] private Image background;

        private static PopupManager _instance;

        private PopupPanel _currentPanel;

        private readonly Dictionary<string, PopupPanel> _prefabs = new Dictionary<string, PopupPanel>();
        private readonly Dictionary<string, PopupPanel> _panelInstances = new Dictionary<string, PopupPanel>();

        private void Awake()
        {
            Assert.IsNull(_instance);
            _instance = this;
            
            foreach (var popupPrefab in popupPrefabs)
            {
                _prefabs[popupPrefab.id] = popupPrefab.prefab;
            }
        }

        public static void Show(string panelId, bool force = false)
        {
            Assert.IsNotNull(_instance);

            switch (force)
            {
                case true when _instance._currentPanel != null:
                    Close();
                    break;
                case false when _instance._currentPanel != null:
                    Debug.LogWarning("Tried to show panel when a panel already exists");
                    return;
            }

            if (!_instance._panelInstances.ContainsKey(panelId))
            {
                var prefab = _instance._prefabs[panelId];
                var instance = Instantiate(prefab, _instance.transform);
                _instance._panelInstances[panelId] = instance;
            }

            _instance._currentPanel = _instance._panelInstances[panelId];
            _instance._currentPanel.gameObject.SetActive(true);
            _instance.background.gameObject.SetActive(true);
        }

        public static void Close()
        {
            Assert.IsNotNull(_instance);
            Assert.IsNotNull(_instance._currentPanel);
            
            _instance._currentPanel.gameObject.SetActive(false);
            _instance._currentPanel = null;
            _instance.background.gameObject.SetActive(false);
        }
    }
}
