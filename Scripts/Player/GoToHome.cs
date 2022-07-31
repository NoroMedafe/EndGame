using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Battery))]
public class GoToHome : MonoBehaviour
{
    [SerializeField] private GameObject _timeLine;
    [SerializeField] private GameObject _player;
    [SerializeField] private Battery _spaceShipBattery;

    private void Start()
    {
        _spaceShipBattery = GetComponent<Battery>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
             if (_spaceShipBattery.CurrentChange == _spaceShipBattery.Capacity)
                EndGame();
    }

    private void EndGame()
    {
        _player.SetActive(false);
        _timeLine.SetActive(true);
    }
}
