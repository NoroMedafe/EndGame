using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Charger : MonoBehaviour
{
    [SerializeField] private int _countCharge = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Battery battery))
            StartCoroutine(Charge(_countCharge, battery));
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.TryGetComponent(out Battery battery))
            StopCoroutine(Charge(_countCharge, battery));
    }

    protected abstract IEnumerator Charge(int count, Battery battery);
}
