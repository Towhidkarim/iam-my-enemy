using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Sound 
{
    [NonSerialized]
    public AudioSource source;
    public AudioClip soundClip;
    public string name;
    [Range(0,1)]
    public float volume = 1;
    public bool loop = false;
}
