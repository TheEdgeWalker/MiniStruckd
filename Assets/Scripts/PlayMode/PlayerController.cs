using System;
using Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace PlayMode
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        
        [SerializeField] private Joystick joystick;
        [SerializeField] private float speed;

        private GameObject _player;
        private Animator _animator;

        private void Awake()
        {
            _player = WorldManager.Instance.Player;
            Assert.IsNotNull(_player);

            _animator = _player.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (_player == null)
                return;

            var direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
            var velocity = direction * Time.fixedDeltaTime * speed;
            if (direction != Vector3.zero)
            {
                _player.transform.position += velocity;
                _player.transform.rotation = Quaternion.LookRotation(direction);
            }

            // only when the object has an animator
            if (_animator != null)
            {
                _animator.SetFloat(MoveSpeed, velocity.magnitude);
            }
        }
    }
}
