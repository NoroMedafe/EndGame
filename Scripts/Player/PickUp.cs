using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject _hands;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BoxCollider _boxCollider;

    private bool _isInhands;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        _boxCollider.enabled = false;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        
        _isInhands = true;
    }

    private void OnMouseUp()
    {
        _boxCollider.enabled = true;
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        
        _isInhands = false;

    }

    private void Update()
    {
        if (_isInhands)
            transform.position = _hands.transform.position;
    }
}
