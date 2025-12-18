using UnityEngine;
namespace Character
{
    [System.Serializable]
    public class ChatacterView
    {
        [SerializeField] private CharacterAnimator _animator;
        public ChatacterView(RuntimeAnimatorController contoller, Animator animator) {
            _animator = new CharacterAnimator(contoller, animator);
        }
        public void Update()
        {
            _animator.Update();
        }
    }
}