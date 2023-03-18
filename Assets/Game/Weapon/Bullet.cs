using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        _t = transform;
        coroutine = StartCoroutine(Die());
        GetComponent<Collider>();
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
        if (coroutine is not null)
        {
            StopCoroutine(coroutine);
        }
        // TODO : Add sound
    }
}
