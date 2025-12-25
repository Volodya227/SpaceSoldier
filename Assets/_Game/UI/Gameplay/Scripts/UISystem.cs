using UnityEngine;
namespace UIGameplay
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Inputs.UIInputs _inputUI = new();
        [SerializeField] private Inputs.UIInputAdapter _inputAdapterUI;
        public Inputs.IUIInputs GetInput => _inputUI;
        private void Awake()
        {
            _inputAdapterUI.Init(_inputUI);
        }
    }
}