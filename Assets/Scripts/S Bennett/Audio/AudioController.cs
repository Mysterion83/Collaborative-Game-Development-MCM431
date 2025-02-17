using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource ThisMusicSource;
    [SerializeField] private AudioSource ThisSFXSource;

    [Header("====== Music Clips ======")]
    [SerializeField] public AudioClip[] musicClips;

    [Header("====== SFX Clips ======")]
    [SerializeField] public AudioClip[] sfxClips;

    public void PlayMusic(AudioClip clipToPlay)
    {
        ThisMusicSource.PlayOneShot(clipToPlay);
    }
    public void PlaySFX(AudioClip clipToPlay)
    {
        ThisSFXSource.PlayOneShot(clipToPlay);
    }

    public void PauseMusic()
    {
        ThisMusicSource.Pause();
    }
    public void PauseSFX()
    {
        ThisSFXSource.Pause();
    }
    public void PauseAllAudio()
    {
        PauseMusic();
        PauseSFX();
    }

    public void StopMusic()
    {
        ThisMusicSource.Stop();
    }
    public void StopSFX()
    {
        ThisSFXSource.Stop();
    }
    public void StopAllAudio()
    {
        StopMusic();
        StopSFX();
    }
}
