using UnityEngine;
namespace Player.Inputs
{
    public abstract class PlayerInput : MonoBehaviour
    {
        protected UIGameplay.Inputs.IUIInputs _inputUI;
        private UIGameplay.Inputs.UIInputsNullReference _inputUINullRef = new();
        public bool Active { get; private set; } = false;
        private void Awake()
        {
            SetUI(null);
        }
        public void SetActive(bool value)
        {
            Active = value;
        }
        public void SetUI(UIGameplay.Inputs.IUIInputs inputUI)
        {
            _inputUI = (inputUI == null) ? _inputUINullRef : inputUI;
        }
        protected readonly PlayerCharacterInput _characterInput = new();
        public PlayerCharacterInput GetCharacterInput => _characterInput;
    }
}