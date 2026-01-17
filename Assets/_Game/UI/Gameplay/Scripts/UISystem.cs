using UnityEngine;
namespace UIGameplay
{
    public sealed class UISystem : MonoBehaviour
    {
        [SerializeField] private Inputs.UIInputs _inputUI = new();
        [SerializeField] private Inputs.UIInputAdapter _inputAdapterUI;
        [SerializeField] private WeaponViewData.UIWeapon _weaponUI;
        [SerializeField] private CharacterViewData.UICharacter _characterUI;
        public WeaponViewData.UIWeapon GetWeaponUI => _weaponUI;
        public CharacterViewData.UICharacter GetCharacterUI => _characterUI;
        public Inputs.IUIInputs GetInput => _inputUI;
        private void Awake()
        {
            _inputAdapterUI.Init(_inputUI);
            _weaponUI.SetState(null);
            _characterUI.SetState(null);
        }
        private void Update()
        {
            _weaponUI.Update();
        }
    }
}