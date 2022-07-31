using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(KeyboardInput))]
public class OpenPanel : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private KeyboardInput _input;

    private void Start()
    {
        _input = GetComponent<KeyboardInput>();
    }

    public void OpenUI()
    {
        _UI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _input.EscapePressed += OpenUI;
    }

    private void OnDisable()
    {
        _input.EscapePressed -= OpenUI;
    }
}
