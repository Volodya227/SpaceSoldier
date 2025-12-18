using UnityEngine;
namespace Character
{
    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField] private Animator _animation;
        [SerializeField] private RuntimeAnimatorController _controller;
        [SerializeField] private ChatacterView _characterView;
        private void Start()
        {
            _characterView = new ChatacterView(_controller, _animation);
        }
        private void Update()
        {
            _characterView.Update();
        }
    }
}