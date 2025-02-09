using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] audioClips;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayAudio(int AudioID, float Volume, float Pitch)
    {
        audioSource.clip = audioClips[AudioID];
        audioSource.volume = Volume;
        audioSource.pitch = Pitch;
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }

    public int GetClipAmount()
    {
        return audioClips.Length;
    }
}
