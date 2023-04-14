using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PlayThisSoundEffect()
    {
        audioSource.Play();
    }
}
