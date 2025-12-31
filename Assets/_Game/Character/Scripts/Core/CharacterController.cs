using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class CharacterConfig
    {
        public Animator Animation;
        public RuntimeAnimatorController Controller;
        public Transform FirstView;
        public Transform ThirdView;
    }
    [System.Serializable]
    public class CharacterController
    {
        private readonly Rigidbody _body;
        private Inputs.CharacterInput _input;
        private readonly ContainerData.CharacterContainerData _state;
        private readonly CharacterConfig _components;
        [SerializeField] private ChatacterView _characterView;
        private readonly CharacterMovement _movement;
        private readonly CharacterRotation _rotation;
        private readonly Transform _firstView;
        private readonly Transform _thirdView;
        public Transform FirstView => _firstView;
        public Transform ThirdView => _thirdView;
        public CharacterController(CharacterConfig components, Rigidbody body)
        {
            _body = body;
            _components = components;
            _state = new ContainerData.CharacterContainerData();
            _characterView = new ChatacterView(_state, _components.Controller, _components.Animation);
            _movement = new CharacterMovement(_state.movementState, _body);
            _rotation = new CharacterRotation(_body.transform);
            _firstView = components.FirstView;
            _thirdView = components.ThirdView;
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
            _rotation.SetInput(_input);
            if (_input != null)
            {
                _input.SetActive(true);
            }
            //reset state if input == null
        }
        public void Update()
        {
            if (_input != null)
            {
                _rotation.Rotate();
            }
        }
        public void FixedUpdate()
        {
            if (_input != null) {
                _movement.Moving();
            }
        }
    }
}