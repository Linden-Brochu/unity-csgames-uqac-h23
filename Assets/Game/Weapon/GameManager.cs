using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    [SerializeField]
    private GameObject bullet;

    public GameObject Bullet => bullet;

    [SerializeField]
    private GameObject bullets;

    public GameObject Bullets => bullets;

    // Start is called before the first frame update
    void Awake()
    {
        Manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
