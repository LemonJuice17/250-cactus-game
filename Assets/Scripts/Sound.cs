using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    [Range(0f, 1.0f)]
    public float volume;
    [Range(-5.0f, 5.0f)]
    public float pitch;

    public bool random;
    [Range(-5.0f, 5.0f)]
    public float minRandPitch;
    [Range(-5.0f, 5.0f)]
    public float maxRandPitch;

    [HideInInspector]
    public AudioSource source;
}
