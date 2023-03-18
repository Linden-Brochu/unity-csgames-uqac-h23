using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carbine : Weapon
{
    [SerializeField]
    protected Transform BulletSpawn;

    [SerializeField]
    private float _timeBetweenBullet = 1f;
    
    private GameManager _gm;

    private bool _canShoot = true;

    protected IEnumerator Shoot()
    {
        SpawnBullet();
        _canShoot = false;
        yield return new WaitForSeconds(_timeBetweenBullet);
        _canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Manager;
    }

    protected override void StartPewPew()
    {
        if (_canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    protected override void EndPewPew()
    {
        
    }

    protected override void SpawnBullet()
    {
        var bullet = Instantiate(_gm.Bullet, BulletSpawn.position, BulletSpawn.transform.rotation, _gm.Bullets.transform);
        var bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.rotation = BulletSpawn.transform.rotation;
    }
}
