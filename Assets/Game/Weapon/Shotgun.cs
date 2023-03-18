using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    const int nb_bullets_per_shots = 8;
    public GameObject Bullet_model;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void StartPewPew()
    {
        for (int i = 0; i < nb_bullets_per_shots; i++)
        {

        }
    }
}
