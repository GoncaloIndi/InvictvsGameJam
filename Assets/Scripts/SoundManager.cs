using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip BreathingSound;
    public AudioClip FireSound;
    public AudioClip JumpSound;
    public AudioClip LandSound;
    public AudioClip RunningSound;
    public AudioClip BombExplosionSound;
    public AudioClip Baby;


    static AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Breathing":

                break;
            case "Fire":
                audioSource.PlayOneShot(FireSound);
                break;
            case "Jump":
                audioSource.PlayOneShot(JumpSound);
                break;
            case "Land":
                audioSource.PlayOneShot(LandSound);
                break;
            case "Running":

                break;
            case "BombExplosion":
                audioSource.PlayOneShot(BombExplosionSound);
                break;
            case "Baby":
                audioSource.PlayOneShot(Baby);
                break;
        }
    }
}
