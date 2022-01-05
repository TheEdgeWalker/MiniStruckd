using System.Collections.Generic;
using Common;
using EditMode.Commands;
using EditMode.UI;
using EditMode.UI.Popups;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace EditMode
{
    public class EditModeManager : MonoBehaviour
    {
        public static EditModeManager Instance { get; private set; }

        public static readonly CommandManager CommandManager = new CommandManager(10);
        
        private static readonly Vector3 MidScreenViewportPoint = new Vector3(0.5f, 0.5f, 0f);
        
        [SerializeField] private Material selectedMaterial;
        [SerializeField] private SelectableObjectControls selectableObjectControls;
        
        private readonly Dictionary<GameObject, SelectableObject> _selectableObjects = new Dictionary<GameObject, SelectableObject>();

        private void Awake()
        {
            Assert.IsNull(Instance);
            Instance = this;
        }

        public void OnPickCityClick()
        {
            PopupManager.Show("CityPicker");
        }

        public void OnAddObjectClick()
        {
            PopupManager.Show("ObjectPicker");
        }

        public void AddObject(GameObject prefab)
        {
            Vector3 position = Vector3.zero;
            var ray = Camera.main.ViewportPointToRay(MidScreenViewportPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                position = hit.point;
            }
            CommandManager.ApplyAndPush(new AddCommand(prefab, WorldManager.Instance.transform, position, OnSelectableInstantiated, OnSelectableDestroy));
        }

        public void Undo()
        {
            CommandManager.UndoAndPop();
        }

        public void Play()
        {
            if (WorldManager.Instance.Player == null || WorldManager.Instance.City == null)
                return;

            foreach (var pair in _selectableObjects)
            {
                pair.Value.Select(false);
                Destroy(pair.Value);
            }
            
            SceneManager.LoadScene("Scenes/PlayMode");
        }

        public void SetPlayer(SelectableObject player)
        {
            if (player == null)
                return;
            
            WorldManager.Instance.Player = player.gameObject;
        }

        private void OnSelectableInstantiated(GameObject go)
        {
            var selectableObject = go.AddComponent<SelectableObject>();
            Assert.IsNotNull(selectableObject);
            selectableObject.Setup(selectedMaterial, OnSelected);
            _selectableObjects[go] = selectableObject;
        }

        private void OnSelectableDestroy(GameObject go)
        {
            if (!_selectableObjects.Remove(go))
            {
                Debug.LogError("Tried to remove object which does not exist!");
            }
        }

        private void OnSelected(SelectableObject selected)
        {
            foreach (var pair in _selectableObjects)
            {
                pair.Value.Select(pair.Value == selected);
            }
            
            selectableObjectControls.SetTarget(selected, selected.gameObject == WorldManager.Instance.Player);
        }
    }
}
