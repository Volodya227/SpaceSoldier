using UnityEngine;
namespace Player.Inputs
{
    public abstract class PlayerInput : MonoBehaviour
    {
        public event System.Action EventChanageCharacter;
        protected bool _isUI = false;
        private bool _bindedUIInput = false;
        protected readonly PlayerCharacterInput _characterInput = new();
        protected readonly PlayerCameraViewInput _cameraViewInput = new();
        protected readonly PlayerWeaponInput _weaponInput = new();
        protected UIGameplay.Inputs.IUIInputs _inputUI;
        private readonly UIGameplay.Inputs.UIInputsNullReference _inputUINullRef = new();
        public PlayerCharacterInput GetCharacterInput => _characterInput;
        public PlayerCameraViewInput CameraViewInput => _cameraViewInput;
        public PlayerWeaponInput GetWeaponInput => _weaponInput;
        public bool Active { get; private set; } = false;
        protected void Awake()
        {
            SetUI(null);
            _cameraViewInput.EventChangeCameraView += SetViewToCharacter;
            SetActiveUIInput(true);//correctly set state
        }
        public void SetActiveUIInput(bool value)
        {
            _isUI = value;
            _cameraViewInput.SetMouseLockMode(!_isUI);
            if (_bindedUIInput)
                UnbindUI();
            if (_isUI)
                BindUI();
            _inputUI?.SetGameplayMode(_isUI);
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
            UnbindUI();
            _inputUI = inputUI ?? _inputUINullRef;
            SetActiveUIInput(_isUI);
        }
        protected void SetCameraViewInput(float x, float y)
        {
            _cameraViewInput.SetXY(x, y);
        }
        protected void ActivateEventChanageCharacter()
        {
            EventChanageCharacter?.Invoke();
        }
        //TODO bind event from UI
        private void BindUI()
        {
            if (!_isUI) return;
            _bindedUIInput = true;
            if (_inputUI == null) return;
            _inputUI.EventAttackPressed += ActivateEventAttackPressed;
            _inputUI.EventAttackReleased += ActivateEventAttackReleased;
            _inputUI.EventReloading += ActivateEventReload;
        }
        private void UnbindUI()
        {
            _bindedUIInput = false;
            if (_inputUI == null) return;
            _inputUI.EventAttackPressed -= ActivateEventAttackPressed;
            _inputUI.EventAttackReleased -= ActivateEventAttackReleased;
            _inputUI.EventReloading -= ActivateEventReload;
        }
        private void ActivateEventAttackPressed()
        {
            if (_weaponInput.Active)
                _weaponInput.InputAttackPressed();
        }
        private void ActivateEventAttackReleased()
        {
            if (_weaponInput.Active)
                _weaponInput.InputAttackReleased();
        }
        private void ActivateEventReload()
        {
            if (_weaponInput.Active)
                _weaponInput.InputReload();
        }
    }
}