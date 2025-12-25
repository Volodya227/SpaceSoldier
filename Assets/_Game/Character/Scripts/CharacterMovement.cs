using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class CharacterMovement
    {
        private readonly float _speed;
        private readonly ContainerData.MovementState _state;
        private Inputs.CharacterInput _input;
        public CharacterMovement(ContainerData.MovementState state)
        {
            _speed = 8;//TODO read from data;
            _state = state;
        }
        public void SetInput(Inputs.CharacterInput input)
        {
            _input = input;
        }
        public void Moving() {
            float x = 0;
            float z = 0;
            if (_input != null) {
                x = _input.MoveX;
                z = _input.MoveZ;
            }
            _state.SetDirectionMoving(x, z);
        }
    }
}