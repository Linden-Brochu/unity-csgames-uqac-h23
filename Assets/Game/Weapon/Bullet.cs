using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    public int timeToLive = 5;

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timeToLive);
        coroutine = null;
        Destroy(gameObject);
    }

    private Coroutine coroutine;

    private Transform _t;

    private AudioSource _audioData;

    private void Awake()
    {
        _t = transform;
        _audioData = GetComponent<AudioSource>();
    }

    void Start()
    {
        coroutine = StartCoroutine(Die());
    }

    void Update()
    {
        var speed = Time.deltaTime * 20;
        if (Physics.Raycast(_t.position, _t.rotation.eulerAngles, out RaycastHit hit, speed + 1f))
        {
            Destroy(gameObject);
        }
        else
        {
            _t.position += _t.forward * speed;
        }
    }

    private void OnDestroy()
    {
        _audioData.Play();
        if (coroutine is not null)
        {
            StopCoroutine(coroutine);
        }
    }
}
