using UnityEngine;
namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        private enum WeaponState
        {
            Cooldown,
            Reloading
        }
        private bool _isFiring;
        private bool _isAutomated;
        private Inputs.WeaponInput _weaponInput;
        private WeaponState _state;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private DecalLifetime _decalLifeTimePrefab;
        private float _reloadTime;
        private float _reloadingTime;
        private float _cooldownTime;
        private int _shootDistance;
        //Ammo
        private int _projectileCount;
        private int _projectileMaxCount;
        private void Awake()
        {
            _reloadTime = 8;
            _cooldownTime = 2;
            _projectileMaxCount = 20;
            _isAutomated = true;
            _shootDistance = 700;
            StartReload();
        }
        private void OnDestroy()
        {
            SetInput(null);
        }
        private void Reload()
        {
            _reloadingTime = 0;
            _projectileCount = _projectileMaxCount;
        }
        private void Cooldown()
        {
            _reloadingTime = 0;
        }
        private void Update()
        {
            Timer();
            if (_isFiring)
            {
                TryShoot();
            }
        }
        private void Timer()
        {
            if (_reloadingTime == 0) return;
            _reloadingTime -= Time.deltaTime;
            if (_reloadingTime < 0)
            {
                if(_state == WeaponState.Reloading) Reload();
                if(_state == WeaponState.Cooldown) Cooldown();
            }
        }
        private void TryShoot()
        {
            if (_reloadingTime > 0) return;
            if (!_isAutomated)
            {
                //if _isAutomated wait Released
                _isFiring = false;
            }

            if (_projectileCount <= 0) return;

            Shoot();
        }
        private void Shoot()
        {
            _projectileCount--;
            Debug.Log("Is shoot");
            Ray ray = new(_targetPoint.position, _targetPoint.forward);
            //Debug.DrawRay(_targetPoint.position, _targetPoint.forward * _shootDistance, Color.red, 10);
            if (Physics.Raycast(ray, out RaycastHit hit, _shootDistance))
            {
                Debug.Log("Is hit");
                Quaternion rotation = Quaternion.LookRotation(hit.normal);

                Instantiate(_decalLifeTimePrefab, hit.point + hit.normal * 0.01f, rotation);
            }

            if (_projectileCount > 0)
                StartCooldown();
        }
        private void StartReload()
        {
            _state = WeaponState.Reloading;
            _reloadingTime = _reloadTime;
        }
        private void StartCooldown()
        {
            _state = WeaponState.Cooldown;
            _reloadingTime = _cooldownTime;
        }
        public void SetInput(Inputs.WeaponInput weaponInput)
        {
            if(_weaponInput != null)
            {
                _weaponInput.EventAttackPressed -= AttackPressed;
                _weaponInput.EventAttackReleased -= AttackReleased;
                _weaponInput.EventReload -= StartReload;
                _weaponInput.SetActive(false);
            }
            _weaponInput = weaponInput;
            if (_weaponInput != null)
            {
                _weaponInput.EventAttackPressed += AttackPressed;
                _weaponInput.EventAttackReleased += AttackReleased;
                _weaponInput.EventReload += StartReload;
                _weaponInput.SetActive(true);
            }
        }
        private void AttackPressed()
        {
            _isFiring = true;
        }
        private void AttackReleased()
        {
            _isFiring = false;
        }
    }
}