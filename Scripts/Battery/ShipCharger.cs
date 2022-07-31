using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Battery))]
public class ShipCharger : Charger
{
    [SerializeField] private Battery _spaceShipBattery;
    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        _spaceShipBattery = GetComponent<Battery>();
    }
  
    protected override IEnumerator Charge(int count, Battery battery)
    {
        while (battery.CurrentChange > 0)
        {
            _spaceShipBattery.Charge(count);
            battery.Discharge(count);

            yield return null;
        }

        if (_spaceShipBattery.CurrentChange == _spaceShipBattery.Capacity)
            _audio.Play();

    }
}
