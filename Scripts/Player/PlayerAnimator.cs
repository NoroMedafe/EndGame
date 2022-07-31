using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(KeyboardInput))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");

    [SerializeField] private Animator _animator;
    [SerializeField] private PhysicsMovement _playerSpeed;
    [SerializeField] private KeyboardInput _input;
    [SerializeField] private int _speedModifier = 100;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<KeyboardInput>();
    }

    public void WaitingState()
    {
        _animator.SetFloat(Speed, _playerSpeed.CurrentPlayerSpeed() *_speedModifier);
    }
   
    public void RunState()
    {
        _animator.SetFloat(Speed, _playerSpeed.CurrentPlayerSpeed() * _speedModifier);
    }

    private void JumpUpState()
    {
        _animator.SetTrigger(Jump);
    }
  
    private void OnEnable()
    {
        _input.JumpPressed += JumpUpState;
    }

    private void OnDisable()
    {
        _input.JumpPressed -= JumpUpState;
    }
}
