using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//No monobehaivour
[System.Serializable] //we add this line because we do not attach this script to any object/button/text etc...so since we call it in AudioManager script, we have to write this
public class MusicScript
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector] //makes it so that source does not show in the inspector. source is public because we want to access it from AudioManager script.
    public AudioSource source;
}
