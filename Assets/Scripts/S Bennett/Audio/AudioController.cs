using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource ThisAudioSource;

    public AudioSource GetAudioSource()
    {
        return ThisAudioSource;
    }
}
