using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _gameOverSound;
    private AudioSource _backgroundMusic;
    private AudioSource _soundEffects;

    private void Awake()
    {
        _backgroundMusic = transform.Find("Background Music").GetComponent<AudioSource>();
        _soundEffects = transform.Find("Sound Effects").GetComponent<AudioSource>();
    }

    public void OnGameStart()
    {
        if (!_backgroundMusic.isPlaying) _backgroundMusic.Play();
        _backgroundMusic.volume = 1;
        _backgroundMusic.pitch = 1;
    }

    public void OnGameOver()
    {
        _soundEffects.PlayOneShot(_gameOverSound);
        if (!_backgroundMusic.isPlaying) _backgroundMusic.Play();
        _backgroundMusic.volume = 0.6f;
        _backgroundMusic.pitch = 0.7f;
    }

    public float GetVolume()
    {
        float[] samples = new float[1024];
        float sum = 0f;
        
        _backgroundMusic.GetOutputData(samples, 0);

        foreach (var sample in samples)
        {
            sum += sample * sample;
        }

        return Mathf.Sqrt(sum / 1024);
    }
}
