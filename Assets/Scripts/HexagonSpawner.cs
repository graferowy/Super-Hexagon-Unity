using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _hexagon;
    [SerializeField] private float _delayTime;
    [SerializeField] private float _spawnTime;
    private GameObject _gameContainer;

    private void Awake()
    {
        _gameContainer = GameObject.Find("Game Container");
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnHexagon), _delayTime, _spawnTime);
    }

    private void SpawnHexagon()
    {
        Instantiate(_hexagon, Vector3.zero, Quaternion.identity, _gameContainer.transform);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
