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
            float x = 0;
            float z = 0;
            if (_input != null) {
                x = _input.MoveX;
                z = _input.MoveZ;
            }
            Vector3 direction = _speed * Time.fixedDeltaTime * (_body.transform.right * x + _body.transform.forward * z).normalized;
            _body.Move(_body.transform.localPosition + direction, _body.transform.rotation);
            _state.SetDirectionMoving(x, z);
        }
    }
}