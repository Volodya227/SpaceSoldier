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
        public Weapon.WeaponController WeaponController;
    }
    [System.Serializable]
    public class CharacterController
    {
        private bool _isAlive;
        private readonly Rigidbody _body;
        private Weapon.WeaponController _weaponController;
        private Inputs.CharacterInput _input;
        private Weapon.Inputs.WeaponInput _weaponInput;
        private readonly ContainerData.CharacterContainerData _state;
        public ContainerData.ICharacterContainerData State => _state;
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

            _weaponController = _components.WeaponController;
            _state.SetWeaponContainerData(_weaponController.GetWeaponContainerData);
            Respawn();
        }
        public void Dispose()
        {
            _characterView.Dispose();
        }
        public void SetInput(Inputs.CharacterInput input, Weapon.Inputs.WeaponInput weaponInput = null)
        {
            if(_input != null)
            {
                _input.SetActive(false);
            }
            _input = input;
            _weaponInput = weaponInput;
            _movement.SetInput(_input);
            _rotation.SetInput(_input);
            if (_isAlive)
            {
                if (_input != null)
                {
                    _input.SetActive(true);
                }
                _weaponController.SetInput(_weaponInput);
            }
            //TODO reset state if input == null
        }
        public void Update()
        {
            if (_isAlive)
            {
                if (_input != null)
                {
                    _rotation.Rotate();
                }
            }
        }
        public void FixedUpdate()
        {
            _movement.Moving();
        }
        public void TakeDamage(float damage) {
            _state.healthState.TakeDamage(damage);
            if (_state.healthState.Health == 0)
            {
                _isAlive = false;
                _input?.SetActive(false);
                _weaponInput?.SetActive(false);
            }
        }
        public void Respawn()
        {
            _state.healthState.SetFullHealth();
            _isAlive = true;
            _input?.SetActive(true);
            if (_weaponController != null)
            {
                _weaponInput?.SetActive(true);
            }
        }
    }
}