using UnityEngine;

namespace EditMode.Commands
{
    public class MoveCommand : TransformCommand
    {
        public MoveCommand(Transform transform, Vector3 startPosition) : base(transform, startPosition)
        {
        }

        public override void Rollback()
        {
            if (_transform == null)
                return;
            
            _transform.position = _vector3;
        }
    }
}
