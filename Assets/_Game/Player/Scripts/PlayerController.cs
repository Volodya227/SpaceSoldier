namespace Player
{
    public class PlayerController
    {
        private readonly Inputs.PlayerInput _input;
        //TODO UI
        private Character.CharacterController _character;
        private readonly CameraView.CameraView _cameraView;
        public PlayerController(Inputs.PlayerInput input, CameraView.CameraView cameraView)
        {
            _input = input;
            _cameraView = cameraView;
            _cameraView.SetInput(_input.CameraViewInput);
        }
        public void Dispose()
        {
        }
        public void SetCharacter(Character.CharacterController character)
        {
            _character = character;
            if (_character == null) {
                return;
            }
            _character.SetInput(_input.GetCharacterInput, _input.GetWeaponInput);
            //TODO connect to UI
            ChangedStateHuman();
        }
        private void ChangedStateHuman()
        {
            CameraView.ViewData view = _cameraView.GetFirstViewData;
            view.parent = _character.FirstView;
            view.minDist = 0;
            view.localView = false;
            view = _cameraView.GetThirdViewData;
            view.parent = _character.ThirdView;
            view.minDist = -8;//TODO
            _cameraView.UpdateView(true);
        }
    }
}