using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{

    [SerializeField] private PhysicsMovement _movement;

    public event Action JumpPressed;
    public event Action Interacted;
    public event Action EscapePressed;
  
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector3(horizontal, 0, vertical));
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
            JumpPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.E))
            Interacted?.Invoke();

        if (Input.GetKey(KeyCode.Escape))
            EscapePressed?.Invoke();
    }
}
