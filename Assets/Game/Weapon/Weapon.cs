using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int Bullet = 20;

    public int GetBullet => Bullet;

    [SerializeField]
    protected GameObject _muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }

    protected abstract void StartPewPew();

    protected abstract void EndPewPew();

    protected abstract void SpawnBullet();
}
