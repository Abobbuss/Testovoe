using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private UIController _uiController;
    [SerializeField] private float _defaultShootInterval = 3f;

    private Coroutine _shootCoroutine;
    private float _speedBullet;
    private float _travelDistance;

    public float SpeedBullet => _speedBullet;
    public float TravelDistance => _travelDistance;

    private void OnEnable()
    {
        _uiController.OnIntervalShootingChanged += HandleIntervalShootingChanged;
    }

    private void OnDisable()
    {
        _uiController.OnIntervalShootingChanged -= HandleIntervalShootingChanged;
    }

    private void Start()
    {
        _shootCoroutine = StartCoroutine(ShootRoutine());
    }

    private void HandleIntervalShootingChanged()
    {
        StopCoroutine(_shootCoroutine);
        _shootCoroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            float shootInterval = _uiController.IntervalShooting;

            if (shootInterval == 0.0)
                shootInterval = _defaultShootInterval;

            Bullet bulletInstance = Instantiate(_bulletPrefab, _muzzlePoint.position, _muzzlePoint.rotation);
            bulletInstance.SetUIController(_uiController);

            yield return new WaitForSecondsRealtime(shootInterval);
        }
    }
}
