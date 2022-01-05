using UnityEngine;

namespace EditMode.UI
{
    public class EditModeCameraController : MonoBehaviour
    {
        [SerializeField] private Joystick xzMoveJoystick;
        [SerializeField] private Joystick yMoveJoystick;
        [SerializeField] private float cameraSpeed;

        private void FixedUpdate()
        {
            if (Camera.main == null)
                return;
            
            var cameraTranslate = new Vector3(xzMoveJoystick.Horizontal, yMoveJoystick.Vertical, xzMoveJoystick.Vertical);
            Camera.main.transform.position += cameraTranslate * Time.fixedDeltaTime * cameraSpeed;
        }
    }
}
