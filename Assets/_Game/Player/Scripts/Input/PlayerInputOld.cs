using UnityEngine;
namespace Player.Inputs
{
    public class PlayerInputOld : PlayerInput
    {
        private bool _dragMouse;
        private void Update()
        {
            if (Active)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    ActivateEventChanageCharacter();
                }
                if (_cameraViewInput.Active)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) || !_isUI) _dragMouse = true;
                    if (Input.GetKeyUp(KeyCode.Mouse0)) _dragMouse = false;
                    if (_dragMouse)
                    {
                        SetCameraViewInput(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    }
                    if (Input.GetKeyDown(KeyCode.V))
                        _cameraViewInput.ActivateChangeView();
                }
                if (_weaponInput.Active)
                {
                    if (!_isUI)
                    {
                        if (Input.GetMouseButtonDown(0))
                            _weaponInput.InputAttackPressed();
                        if (Input.GetMouseButtonUp(0))
                            _weaponInput.InputAttackReleased();
                    }
                    if (Input.GetKeyDown(KeyCode.R))
                        _weaponInput.InputReload();
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