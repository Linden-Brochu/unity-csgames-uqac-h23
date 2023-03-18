using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Carbine : Weapon
{
    [SerializeField]
    protected Transform bulletSpawn;

    [SerializeField]
    private float timeBetweenBullet = 1f;
    
    private GameManager _gm;

    private bool _canShoot = true;

    protected IEnumerator Shoot()
    {
        _canShoot = false;
        SpawnBullet();
        yield return new WaitForSeconds(timeBetweenBullet);
        _canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Manager;
    }

    protected override void StartPewPew()
    {
        if (_canShoot && bullet > 0)
        {
            StartCoroutine(Shoot());
            GetComponentInChildren<MuzzleFlash>().Play();
            _audioData.Play();
            bullet--;
        }
    }

    protected override void EndPewPew()
    {
        
    }

    protected override void SpawnBullet()
    {
        var bullet = Instantiate(_gm.Bullet, bulletSpawn.position, bulletSpawn.transform.rotation, _gm.Bullets.transform);
        var bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.rotation = bulletSpawn.transform.rotation;
        
    }
}
