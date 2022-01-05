using UnityEngine;

namespace EditMode.Commands
{
    public class ScaleCommand : TransformCommand
    {
        public ScaleCommand(Transform transform, Vector3 scale) : base(transform, scale)
        {
        }

        public override void Rollback()
        {
            if (_transform == null)
                return;

            _transform.localScale = _vector3;
        }
    }
}
