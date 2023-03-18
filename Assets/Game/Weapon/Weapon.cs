using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int bullet = 20;

    [SerializeField]
    private int initialBullet = 20;
    
    public int GetBullet => bullet;
    
    protected AudioSource _audioData;
    
    void Awake()
    {
        _audioData = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPewPew();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndPewPew();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            bullet = initialBullet;
        }
    }

    protected abstract void StartPewPew();

    protected abstract void EndPewPew();

    protected abstract void SpawnBullet();
}
