using UnityEngine;
namespace Player.Inputs
{
    public class PlayerInputOld : PlayerInput
    {
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
                    if (_isUI)
                    {
                        SetCameraViewInput(_inputUI.MoveX/5, 0);
                    }
                    else
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