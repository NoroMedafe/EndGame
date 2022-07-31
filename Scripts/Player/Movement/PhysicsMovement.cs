using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private Transform _camera;

    private float _turnSmoothVelocity;
    private Vector3 _previousPosition;

    public void Move(Vector3 direction)
    {

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 direcrionAlongSurface = _surfaceSlider.Project(moveDirection.normalized);
            Vector3 offset = direcrionAlongSurface * (_speed * Time.deltaTime);

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _rigidbody.MovePosition(_rigidbody.position + offset);
            _animator.RunState();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.WaitingState();
        }
    }

    public float CurrentPlayerSpeed()
    {
        float speed = (transform.position - _previousPosition).sqrMagnitude;
        _previousPosition = transform.position;
     
        return speed;
    }
}
