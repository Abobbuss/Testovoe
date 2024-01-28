using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 10f;
    [SerializeField] private float _defaultTravelDistance = 10f;

    private UIController _uiController;
    private float _traveledDistance = 0f;
    private float _speedBullet;
    private float _travelDistance;

    private void Start()
    {
        _speedBullet = _uiController.BulletSpeed;
        _travelDistance = _uiController.BulletDistance;
    }

    private void Update()
    {
        if (_speedBullet == 0.0)
            _speedBullet = _defaultSpeed;

        if (_travelDistance == 0.0)
            _travelDistance = _defaultTravelDistance;

        if (_travelDistance >= _traveledDistance)
            Move(_speedBullet);
        else
            Destroy(gameObject);

        _traveledDistance += _speedBullet * Time.deltaTime;
    }

    private void Move(float speedBullet)
    {
        transform.Translate(transform.forward * speedBullet * Time.deltaTime);
    }

    public void SetUIController(UIController uiController)
    {
        _uiController = uiController;
    }
}
