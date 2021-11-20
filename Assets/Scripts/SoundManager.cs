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
        }
    }
}
