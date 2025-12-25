namespace Player
{
    public class PlayerController
    {
        private readonly Inputs.PlayerInput _input;
        //TODO UI
        private Character.CharacterController _currentCharacter;
        public PlayerController(Inputs.PlayerInput input)
        {
            _input = input;
        }
        public void Dispose()
        {
        }
        public void SetCharacter(Character.CharacterController character)
        {
            _currentCharacter = character;
            if (_currentCharacter == null) {
                return;
            }
            _currentCharacter.SetInput(_input.GetCharacterInput);
            //TODO connect to UI
        }
    }
}