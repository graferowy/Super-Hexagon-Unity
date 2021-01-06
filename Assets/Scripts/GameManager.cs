using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private AudioManager _audioManager;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.GetComponent<PlayerController>().OnPlayerDeath += GameOver;
        }
    }

    private void Start()
    {
        _audioManager.OnGameStart();
    }

    private void GameOver()
    {
        _audioManager.OnGameOver();
    }
    
    private void OnDisable()
    {
        if (_player != null)
        {
            _player.GetComponent<PlayerController>().OnPlayerDeath -= GameOver;
        }
    }
}
