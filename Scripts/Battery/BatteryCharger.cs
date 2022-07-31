using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharger : Charger
{
    protected override IEnumerator Charge(int count, Battery battery)
    {
        while (battery.CurrentChange < battery.Capacity)
        {
            battery.Charge(count);

            yield return null;
        }
    }
}
