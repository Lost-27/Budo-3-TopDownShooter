using System;
using Lean.Pool;
using TDS.Game.Input;
using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _shootDelay = 0.5f;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private int _maxAmmo = 8;

        private IInputService _inputService;
        private float _currentDelay;
        private int _currenAmmo;

        #endregion
        

        #region Events
        public event Action OnAmmoChanged;

        #endregion

        #region Properties
        public int CurrentAmmo => _currenAmmo;

        #endregion
        

        #region Unity lifecycle

        private void Awake()
        {
            _currenAmmo = _maxAmmo;
            OnAmmoChanged?.Invoke();
        }

        private void Start()
        {
            _inputService = Services.Container.Get<IInputService>();
        }

        private void Update()
        {
            DecrementTimer(Time.deltaTime);

            if (_inputService.IsFireButtonClicked() && CanShoot() && HaveAmmunition())
            {
                Attack();
                _currenAmmo--;
                OnAmmoChanged?.Invoke();
            }
               
        }

        #endregion
        

        #region Private methods

        private void DecrementTimer(float deltaTime) =>
            _currentDelay -= deltaTime;

        private bool CanShoot() =>
            _currentDelay <= 0f;

        private bool HaveAmmunition() =>
            _currenAmmo > 0;

        private void Attack()
        {
            CreateBullet();
            _playerAnimation.PlayAttack();
            SetDelay();
        }

        private void SetDelay() =>
            _currentDelay = _shootDelay;

        private void CreateBullet() =>
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletSpawnPointTransform.rotation);
        
        public void AddAmmo(int ammoPoints)
        {
            if (_currenAmmo >= _maxAmmo)
                return;

            _currenAmmo += ammoPoints;
            _currenAmmo = Mathf.Min(_currenAmmo, _maxAmmo);

            OnAmmoChanged?.Invoke();
        }

        #endregion
    }
}