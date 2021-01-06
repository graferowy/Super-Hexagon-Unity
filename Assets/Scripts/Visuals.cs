using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Visuals : MonoBehaviour
{
    [SerializeField] private List<Color> _bgColors;
    private Camera _camera;
    private Color _targetColor;
    private GameObject _gameContainer;
    private GameObject _centerPoint;
    private AudioManager _audioManager;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _targetColor = _camera.backgroundColor;
        _gameContainer = GameObject.Find("Game Container");
        _centerPoint = GameObject.Find("Center Point");
        _audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    private void Update()
    {
        ChangeBackgroundColor();
        RotateGameContainer();
        PulsateCenterPoint();
    }

    private void ChangeBackgroundColor()
    {
        if (_camera.backgroundColor == _targetColor)
        {
            _targetColor = _bgColors.First();
            _bgColors.Remove(_targetColor);
            _bgColors.Add(_targetColor);
        }

        _camera.backgroundColor = Color.Lerp(_camera.backgroundColor, _targetColor, Time.deltaTime * 5f);
    }

    private void RotateGameContainer()
    {
        _gameContainer.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 100f);
    }

    private void PulsateCenterPoint()
    {
        float currentVolume = _audioManager.GetVolume() * 10f;

        _centerPoint.transform.localScale = new Vector3(5f + currentVolume, 5f + currentVolume, 1f);
    }
}
