using UnityEngine;
namespace Character {
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterControllerBehaviour : MonoBehaviour, Weapon.ITakeDamageable
    {
        [SerializeField] private CharacterConfig _inputComponents;
        [SerializeField] private CharacterController _core;
        public CharacterController Core => _core;
        private void Awake()
        {
            _core = new(_inputComponents, GetComponent<Rigidbody>());
        }
        private void OnDestroy()
        {
            _core.Dispose();
            _core.SetInput(null, null);
        }
        private void FixedUpdate()
        {
            _core.FixedUpdate();
        }
        private void Update()
        {
            _core.Update();
        }
        public void TakeDamage(float damage) {
            _core.TakeDamage(damage);
        }
    }
}