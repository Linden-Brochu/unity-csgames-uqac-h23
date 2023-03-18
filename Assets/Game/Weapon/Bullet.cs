using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    public int timeToLive = 5;

    private bool _isEnded = false;

    [SerializeField]
    private GameObject child;

    /// <summary>
    /// Time to live coroutine
    /// </summary>
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timeToLive);
        coroutine = null;
        StartCoroutine(End());
    }

    /// <summary>
    /// Start the destroy sequence of the bullet
    /// </summary>
    /// <param name="withSound"></param>
    private IEnumerator End(bool withSound = false)
    {
        child.SetActive(false);
        _isEnded = true;
        if (withSound)
        {
            _audioData.Play();
        }
        
        if (coroutine is not null)
        {
            StopCoroutine(coroutine);
        }

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    } 

    /// <summary>
    /// Movement Coroutine
    /// </summary>
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
        if (!_isEnded)
        {
            var speed = Time.deltaTime * 50;
            if (Physics.Raycast(_t.position, _t.rotation.eulerAngles, out RaycastHit hit, speed + 5f))
            {
                StartCoroutine(End(true));
            }
            else
            {
                _t.position += _t.forward * speed;
            }
        }
        
    }
}