using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

     [SerializeField]
    private GameObject _bullet;

    public GameObject Bullet => _bullet;

    // Start is called before the first frame update
    void Start()
    {
        Manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
