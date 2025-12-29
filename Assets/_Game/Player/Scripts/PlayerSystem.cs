using UnityEngine;
namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        private Inputs.PlayerInput _input;
        private PlayerController _player;
        private Character.CharacterSystem _characterSystem;
        private UIGameplay.UISystem _UI;
        private CameraView.CameraView _cameraView;
        public void Init(Inputs.PlayerInput input, Character.CharacterSystem characterManager, UIGameplay.UISystem UI, CameraView.CameraView cameraView)
        {
            _input = input;
            _cameraView = cameraView;
            _characterSystem = characterManager;
            _UI = UI;
            _input.SetUI(_UI.GetInput);
        }
        private void Start()
        {
            _player = new PlayerController(_input, _cameraView);
            _input.SetActive(true);
            SetCharacter();
        }
        private void OnDestroy()
        {
            _player.Dispose();
            _input.SetUI(null);
            _input.SetActive(false);
        }
        private void SetCharacter()
        {
            //TODO Change Character by CharacterSystem
            _player.SetCharacter(_characterSystem.GetChatacter);
        }
    }
}