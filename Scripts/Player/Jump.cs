using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheckObject;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _maxDistance = 0.4f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jumping()
    {

        if (Physics.Raycast(_groundCheckObject.position, Vector3.down, _maxDistance, _groundMask))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
