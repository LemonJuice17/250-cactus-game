using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    public Sound[] sounds;
    private void Awake()
    {
        Singleton();

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound " + name + " doesn't exist");
            return;
        }

        if (sound.random)
        {
            sound.source.pitch = sound.pitch + UnityEngine.Random.Range(sound.minRandPitch, sound.maxRandPitch);
        }

        sound.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound " + name + " doesn't exist");
            return;
        }

        if (sound.random)
        {
            sound.source.pitch = sound.pitch + UnityEngine.Random.Range(sound.minRandPitch, sound.maxRandPitch);
        }

        sound.source.PlayOneShot(sound.source.clip, sound.source.volume);
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
