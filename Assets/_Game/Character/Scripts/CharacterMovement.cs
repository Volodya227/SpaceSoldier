using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class CharacterMovement
    {
        private readonly Rigidbody _body;
        private readonly float _speed;
        private readonly ContainerData.MovementState _state;
        private Inputs.CharacterInput _input;
        public CharacterMovement(ContainerData.MovementState state, Rigidbody body)
        {
            _speed = 6;//TODO read from data;
            _state = state;
            _body = body;
        }
        public void SetInput(Inputs.CharacterInput input)
        {
            _input = input;
        }
        public void Moving() {
            Vector3 direction = _speed * Time.fixedDeltaTime * (_body.transform.right * _input.MoveX + _body.transform.forward * _input.MoveZ).normalized;
            _body.Move(_body.transform.localPosition + direction, _body.transform.rotation);
            _state.SetDirectionMoving(_input.MoveX, _input.MoveZ);
        }
    }
}