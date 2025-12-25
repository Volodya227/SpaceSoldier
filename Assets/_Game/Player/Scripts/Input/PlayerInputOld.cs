using UnityEngine;
namespace Player.Inputs
{
    public class PlayerInputOld : PlayerInput
    {
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