using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip gameoverSound, jumpSound, swordattackSound,mainthemeSound;
    static AudioSource audioSource;
    
    void Start()
    {
        gameoverSound = Resources.Load<AudioClip>("gameover");
        jumpSound = Resources.Load<AudioClip>("jump");
        swordattackSound = Resources.Load<AudioClip>("swordattack");
        mainthemeSound = Resources.Load<AudioClip>("maintheme");

        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gameover":
                audioSource.PlayOneShot(gameoverSound);
                break;
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "swordattack":
                audioSource.PlayOneShot(swordattackSound);
                break;
            case "maintheme":
                audioSource.PlayOneShot(mainthemeSound);
                break;
        }
    }
    
    void Update()
    {
        
    }
}
