using System;
using UnityEngine;

namespace EditMode.Commands
{
    public class AddCommand : ICommand
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly Vector3 _position;
        private readonly Action<GameObject> _onInstantiated;
        private readonly Action<GameObject> _onDestroy;
        
        private GameObject _instance;

        public AddCommand(GameObject prefab, Transform parent, Vector3 position, Action<GameObject> OnInstantiated, Action<GameObject> OnDestroy)
        {
            _prefab = prefab;
            _parent = parent;
            _position = position;
            _onInstantiated = OnInstantiated;
            _onDestroy = OnDestroy;
        }

        public void Apply()
        {
            _instance = GameObject.Instantiate(_prefab, _position, Quaternion.identity, _parent);
            _onInstantiated?.Invoke(_instance);
        }

        public void Rollback()
        {
            _onDestroy?.Invoke(_instance);
            GameObject.Destroy(_instance);
        }
    }
}
