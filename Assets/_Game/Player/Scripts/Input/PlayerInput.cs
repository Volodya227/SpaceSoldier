using UnityEngine;
namespace Player.Inputs
{
    public abstract class PlayerInput : MonoBehaviour
    {
        public event System.Action EventChanageCharacter;
        protected readonly PlayerCharacterInput _characterInput = new();
        protected readonly PlayerCameraViewInput _cameraViewInput = new();
        protected readonly PlayerWeaponInput _weaponInput = new();
        protected UIGameplay.Inputs.IUIInputs _inputUI;
        private readonly UIGameplay.Inputs.UIInputsNullReference _inputUINullRef = new();
        public PlayerCharacterInput GetCharacterInput => _characterInput;
        public PlayerCameraViewInput CameraViewInput => _cameraViewInput;
        public PlayerWeaponInput GetWeaponInput => _weaponInput;
        public bool Active { get; private set; } = false;
        private void Awake()
        {
            SetUI(null);
            _cameraViewInput.EventChangeCameraView += SetViewToCharacter;
        }
        private void OnDestroy()
        {
            _cameraViewInput.EventChangeCameraView -= SetViewToCharacter;
        }
        private void SetViewToCharacter()
        {
            _characterInput.SetView(_cameraViewInput.CameraRotationX, _cameraViewInput.CameraRotationY);
        }
        public void SetActive(bool value)
        {
            Active = value;
        }
        public void SetUI(UIGameplay.Inputs.IUIInputs inputUI)
        {
            _inputUI = inputUI ?? _inputUINullRef;
        }
        protected void SetCameraViewInput(float x, float y)
        {
            _cameraViewInput.SetXY(x, y);
        }
        protected void ActivateEventChanageCharacter()
        {
            EventChanageCharacter?.Invoke();
        }
    }
}