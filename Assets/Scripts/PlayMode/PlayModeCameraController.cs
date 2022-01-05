using System;
using Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace PlayMode
{
    public class PlayModeCameraController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private GameObject _player;
        private Vector3 _offset;

        private void Awake()
        {
            _player = WorldManager.Instance.Player;
            Assert.IsNotNull(_player);

            _offset = mainCamera.transform.position;
        }

        private void FixedUpdate()
        {
            if (_player == null)
                return;

            mainCamera.transform.position = _player.transform.position + _offset;
        }
    }
}
