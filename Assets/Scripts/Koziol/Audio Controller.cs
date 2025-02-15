using System;
using UnityEngine;

[Obsolete("AudioController is a temporary system. Do not use it in production code and prefabs.", false)]
public class AudioController : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField]
    AudioClip[] _audioClips;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            _audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayAudio(int AudioID, float Volume, float Pitch)
    {
        _audioSource.clip = _audioClips[AudioID];
        _audioSource.volume = Volume;
        _audioSource.pitch = Pitch;
        _audioSource.Play();
    }
    public void Stop()
    {
        _audioSource.Stop();
    }

    public int GetClipAmount()
    {
        return _audioClips.Length;
    }
}
