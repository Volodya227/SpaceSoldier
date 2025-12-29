using UnityEngine;
namespace Player.Inputs
{
    public class PlayerInputOld : PlayerInput
    {
        private void Update()
        {
            if (_cameraViewInput.Active)
            {
                SetCameraViewInput(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                if (Input.GetKeyDown(KeyCode.V))
                {
                    _cameraViewInput.ActivateChangeView();
                }
            }
        }
        private void FixedUpdate()
        {
            if (Active) {
                if (_characterInput.Active)
                {
                    _characterInput.SetMoving(Input.GetAxis("Horizontal") + _inputUI.MoveX, Input.GetAxis("Vertical") + _inputUI.MoveZ);
                }
            }
        }
    }
}