using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(KeyboardInput))]
public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _interactDistance;
    [SerializeField] private Transform _hitPosition;

    private KeyboardInput _input;

    private void Start()
    {
      _input = GetComponent<KeyboardInput>();

    }
    public void Interact()
    {
        Ray ray = new Ray(_hitPosition.position, _hitPosition.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, _interactDistance))
            if (hit.collider.TryGetComponent(out Door door))
                door.Interact();
    }
    private void OnEnable()
    {
        _input.Interacted += Interact;
    }

    private void OnDisable()
    {
        _input.Interacted -= Interact;

    }
}
