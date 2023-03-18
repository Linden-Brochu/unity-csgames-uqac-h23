using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public void Play()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
}
