using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class CharacterAnimator
    {
        [SerializeField, Range(-1, 1)] private float _moveX;
        [SerializeField, Range(-1, 1)] private float _moveZ;
        private readonly RuntimeAnimatorController _contoller;
        private readonly Animator _animator;
        public CharacterAnimator(RuntimeAnimatorController contoller, Animator animator)
        {
            _contoller = contoller;
            _animator = animator;
            _animator.runtimeAnimatorController = _contoller;
            _moveX = 0;
            _moveZ = 0;
        }
        private void UpdateMoving()
        {
            //TODO subscribe to event
            //_moveX = 
            //_moveZ = 
            _animator.SetFloat("MoveX", _moveX);
            _animator.SetFloat("MoveZ", _moveZ);
        }
        public void Update() {
            UpdateMoving();
        }
    }
}