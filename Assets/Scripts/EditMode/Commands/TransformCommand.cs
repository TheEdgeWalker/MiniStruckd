using UnityEngine;

namespace EditMode.Commands
{
    public abstract class TransformCommand : ICommand
    {
        protected readonly Transform _transform;
        protected readonly Vector3 _vector3;
        
        protected TransformCommand(Transform transform, Vector3 vector3)
        {
            _transform = transform;
            _vector3 = vector3;
        }
        
        public void Apply()
        {
            // nothing happens here because the object is already transformed
        }

        public abstract void Rollback();
    }
}
