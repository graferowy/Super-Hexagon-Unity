using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hexagon : MonoBehaviour
{
    [SerializeField] private float _scalingSpeed;
    private Transform _transform;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _transform = transform;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.5f;
        _lineRenderer.endWidth = 0.5f;
        _transform.Rotate(0.0f, 0.0f, Random.Range(0, 6) * 60.0f, Space.Self);
    }

    private void Update()
    {
        Shrink();
    }

    private void Shrink()
    {
        _scalingSpeed += Time.deltaTime;

        _transform.localScale = Vector3.Lerp(_transform.localScale, Vector3.zero, _scalingSpeed * Time.deltaTime);

        if (_transform.localScale.x <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
