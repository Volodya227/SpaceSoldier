using UnityEngine;
using UnityEngine.EventSystems;
namespace Systems.DI
{
    public class BootstrapSceneGameplay : MonoBehaviour
    {
        [SerializeField] private Character.SpawnCharacters _spawnCharacters;
        [SerializeField] private Character.CharacterSystem _characterSystemPrefab;
        private Character.CharacterSystem _characterSystem;
        [SerializeField] private Player.Inputs.PlayerInput _playerInputPrefab;
        private Player.Inputs.PlayerInput _playerInput;
        [SerializeField] private Player.PlayerSystem _playerSystemPrefab;
        private Player.PlayerSystem _playerSystem;
        [SerializeField] private UIGameplay.UISystem _UIPrefab;
        private UIGameplay.UISystem _UI;
        [SerializeField] private CameraView.CameraView _cameraViewPrefab;
        private CameraView.CameraView _cameraView;
        [SerializeField] private EventSystem _eventSystem;
        private IBootstrapEvents _bootstrapEvents;
        private void Awake()
        {
            if(Bootstrap.Get != null)
            {
                _bootstrapEvents = Bootstrap.Get.BootstrapEvents;
            }
            InitCharacters();
            InitUI();
            InitInput();
            InitCamera();
            InitPlayerSystem();
        }
        private void OnDestroy()
        {
            
        }
        private void InitCharacters()
        {
            _characterSystem = Instantiate(_characterSystemPrefab);
            _characterSystem.Init(_spawnCharacters);
            _characterSystem.enabled = true;
        }
        private void InitUI()
        {
            _UI = Instantiate(_UIPrefab);
        }
        private void InitInput()
        {
            //from Global Container
            if (ServiceEntryPointReadonly.GlobalContainerSystems != null)
                _playerInput = ServiceEntryPointReadonly.GlobalContainerSystems.PlayerInput;
            else
                _playerInput = Instantiate(_playerInputPrefab);
            _playerInput.SetEventSystem(_eventSystem);
        }
        private void InitCamera()
        {
            _cameraView = Instantiate(_cameraViewPrefab);
        }
        private void InitPlayerSystem()
        {
            _playerSystem = Instantiate(_playerSystemPrefab);
            _playerSystem.Init(_playerInput, _characterSystem, _UI, _cameraView);
            _playerSystem.enabled = true;
        }
        private void ReturnTOMainMenu()
        {
            if (_bootstrapEvents == null) return;
            _bootstrapEvents.ActivateEventLoadScene(1);
        }
    }
}