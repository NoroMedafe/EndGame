using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private int _capacity;

    private int _currentCharge;
    public int CurrentChange => _currentCharge;
    public int Capacity => _capacity;
    public Light Light => _light;
    
    public void Charge(int count)
    {
        _currentCharge = Mathf.Clamp(_currentCharge + count, 0, _capacity);

        if (_currentCharge == _capacity)
            _light.enabled = true;

    }

    public void Discharge(int count)
    {
        _currentCharge = Mathf.Clamp(_currentCharge - count, 0, _capacity);

        if (_currentCharge != _capacity)
            _light.enabled = false;
    }
}
