using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField bulletSpeedInputField;
    [SerializeField] private TMP_InputField bulletDistanceInputField;
    [SerializeField] private TMP_InputField intervalShootingInputField;

    private float _bulletSpeed = 0.0f;
    private float _bulletDistance = 0.0f;
    private float _intervalShooting = 0.0f;

    public float BulletSpeed => _bulletSpeed;
    public float BulletDistance => _bulletDistance;
    public float IntervalShooting => _intervalShooting;

    public event Action OnIntervalShootingChanged;

    private void Start()
    {
        bulletSpeedInputField.onEndEdit.AddListener(value => UpdateValue(ref _bulletSpeed, value));
        bulletDistanceInputField.onEndEdit.AddListener(value => UpdateValue(ref _bulletDistance, value));
        intervalShootingInputField.onEndEdit.AddListener(value => UpdateIntervalShooting(ref _intervalShooting, value));
    }

    private void UpdateValue(ref float variable, string inputValue)
    {
        if (float.TryParse(inputValue, out float result))
            variable = result;
        else
            Debug.LogError($"Error {nameof(variable)}: {inputValue}");
    }

    private void UpdateIntervalShooting(ref float variable, string inputValue)
    {
        UpdateValue(ref variable, inputValue);

        OnIntervalShootingChanged?.Invoke();
    }
}