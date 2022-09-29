using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAudio : MonoBehaviour
{
    public AudioClip Sound;
    private AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = Sound;
        audio.loop = true;
        audio.Play();
    }
}
