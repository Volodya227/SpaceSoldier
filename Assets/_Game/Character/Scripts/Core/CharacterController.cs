using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class CharacterConfig
    {
        public Animator Animation;
        public RuntimeAnimatorController Controller;
    }
    [System.Serializable]
    public class CharacterController
    {
        private readonly Rigidbody _body;
        private Inputs.CharacterInput _input;
        private ContainerData.CharacterContainerData _state;
        private readonly CharacterConfig _components;
        [SerializeField] private ChatacterView _characterView;
        private readonly CharacterMovement _movement;
        public CharacterController(CharacterConfig components, Rigidbody body)
        {
            _components = components;
            _state = new ContainerData.CharacterContainerData();
            _characterView = new ChatacterView(_state, _components.Controller, _components.Animation);
            _movement = new CharacterMovement(_state.movementState);
            _body = body;
        }
        public void Dispose()
        {
            _characterView.Dispose();
        }
        public void SetInput(Inputs.CharacterInput input)
        {
            if(_input != null)
            {
                _input.SetActive(false);
            }
            _input = input;
            _movement.SetInput(_input);
            if (_input != null)
            {
                _input.SetActive(true);
            }
        }
        public void FixedUpdate()
        {
            _movement.Moving();
        }
    }
}