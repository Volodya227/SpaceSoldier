using UnityEngine;
namespace Character
{
    public class CharacterRotation
    {
        private readonly Transform _transform;
        private readonly float _maxRotationSpeed;
        private readonly Inputs.CharacterInput _input;
        public CharacterRotation(Transform transform, Inputs.CharacterInput input)
        {
            _transform = transform;
            _maxRotationSpeed = 30;
            _input = input;
        }
        public void Rotate()
        {
            //_transform.localRotation = Quaternion.Euler(0, _input.Yrotation, 0);//TODO limit
        }
    }
}