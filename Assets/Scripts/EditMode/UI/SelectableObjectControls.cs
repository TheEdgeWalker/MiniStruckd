using EditMode.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace EditMode.UI
{
    public class SelectableObjectControls : MonoBehaviour
    {
        [SerializeField] private EditModeManager editModeManager;
        [SerializeField] private Toggle playerToggle;
        [SerializeField] private Joystick xzMoveJoystick;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Joystick scaleJoystick;
        [SerializeField] private float scaleSpeed;
        [SerializeField] private Joystick rotateJoystick;
        [SerializeField] private float rotateSpeed;

        private SelectableObject _target;

        private Vector3 _startPosition;
        private Vector3 _startScale;
        private Quaternion _startRotation;

        private void OnEnable()
        {
            xzMoveJoystick.OnPointerDownCallback += OnOnXZMoveStart;
            xzMoveJoystick.OnPointerUpCallback += OnXZMoveEnd;

            scaleJoystick.OnPointerDownCallback += OnScaleStart;
            scaleJoystick.OnPointerUpCallback += OnScaleEnd;

            rotateJoystick.OnPointerDownCallback += OnRotateStart;
            rotateJoystick.OnPointerUpCallback += OnRotateEnd;
        }

        private void OnDisable()
        {
            xzMoveJoystick.OnPointerDownCallback -= OnOnXZMoveStart;
            xzMoveJoystick.OnPointerUpCallback -= OnXZMoveEnd;
            
            scaleJoystick.OnPointerDownCallback -= OnScaleStart;
            scaleJoystick.OnPointerUpCallback -= OnScaleEnd;

            rotateJoystick.OnPointerDownCallback -= OnRotateStart;
            rotateJoystick.OnPointerUpCallback -= OnRotateEnd;
        }

        private void FixedUpdate()
        {
            if (_target == null)
                return;
            
            var t = _target.transform;
            t.position += new Vector3(xzMoveJoystick.Horizontal, 0f, xzMoveJoystick.Vertical) * Time.fixedDeltaTime * moveSpeed;
            t.localScale += new Vector3(scaleJoystick.Vertical, scaleJoystick.Vertical, scaleJoystick.Vertical) * Time.fixedDeltaTime * scaleSpeed;
            t.Rotate(Vector3.up, rotateJoystick.Horizontal * Time.fixedDeltaTime * rotateSpeed);
        }

        public void OnDisableTarget()
        {
            if (_target == null)
                return;
            
            EditModeManager.CommandManager.ApplyAndPush(new DisableCommand(_target.gameObject));
        }

        public void OnSetPlayer(Toggle toggle)
        {
            if (_target != null && toggle.isOn)
                editModeManager.SetPlayer(_target);
        }

        public void SetTarget(SelectableObject target, bool isPlayer)
        {
            _target = target;
            playerToggle.isOn = isPlayer;
        }

        private void OnOnXZMoveStart()
        {
            if (_target == null)
                return;
            
            _startPosition = _target.transform.position;
        }

        private void OnXZMoveEnd()
        {
            if (_target == null)
                return;
            
            EditModeManager.CommandManager.ApplyAndPush(new MoveCommand(_target.transform, _startPosition));
        }

        private void OnScaleStart()
        {
            if (_target == null)
                return;

            _startScale = _target.transform.localScale;
        }

        private void OnScaleEnd()
        {
            if (_target == null)
                return;
            
            EditModeManager.CommandManager.ApplyAndPush(new ScaleCommand(_target.transform, _startScale));
        }

        private void OnRotateStart()
        {
            if (_target == null)
                return;

            _startRotation = _target.transform.rotation;
        }

        private void OnRotateEnd()
        {
            if (_target == null)
                return;
            
            EditModeManager.CommandManager.ApplyAndPush(new RotationCommand(_target.transform, _startRotation));
        }
    }
}
