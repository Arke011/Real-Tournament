using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    static AudioSource source;
    public AudioClip rifleSound;
    public AudioClip shotgunSound;
    public AudioClip waveEndSound;
    public AudioClip waveStartSound;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void playShotgun()
    {
        source.PlayOneShot(shotgunSound);
    }

    public void playRifle()
    {
        source.PlayOneShot(rifleSound);
    }

    public void waveStart()
    {
        source.PlayOneShot(waveStartSound);
    }

    public void waveEnd()
    {
        source.PlayOneShot(waveEndSound);
    }
}