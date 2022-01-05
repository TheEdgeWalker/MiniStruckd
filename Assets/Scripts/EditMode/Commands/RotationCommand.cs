using UnityEngine;

namespace EditMode.Commands
{
    public class RotationCommand : ICommand
    {
        private Transform _transform;
        private Quaternion _rotation;
        
        public RotationCommand(Transform transform, Quaternion rotation)
        {
            _transform = transform;
            _rotation = rotation;
        }

        public void Apply()
        {
            // nothing happens here because the object is already rotated
        }

        public void Rollback()
        {
            if (_transform == null)
                return;

            _transform.rotation = _rotation;
        }
    }
}
