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

    private bool _canShoot = true;

    protected IEnumerator Shoot()
    {
        _canShoot = false;
        SpawnBullet();
        yield return new WaitForSeconds(timeBetweenBullet);
        _canShoot = true;
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
        var bullet = Instantiate(GameManager.Manager.Bullet, bulletSpawn.position, bulletSpawn.transform.rotation, GameManager.Manager.Bullets.transform);
        var bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.rotation = bulletSpawn.transform.rotation;
        
    }

    public override void Select()
    {
        _canShoot = true;
    }

    public override void UnSelect()
    {
        
    }
}
