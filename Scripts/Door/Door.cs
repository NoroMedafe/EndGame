using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audio;

    private static readonly int Interaction = Animator.StringToHash("character_nearby");

    private bool _isOpen = false;

    private void Start()
    {
      _animator =  GetComponent<Animator>();
    }

    public void Interact()
    {
        _isOpen = !_isOpen;
        _animator.SetBool(Interaction, _isOpen );
        _audio.Play();

    }

}
