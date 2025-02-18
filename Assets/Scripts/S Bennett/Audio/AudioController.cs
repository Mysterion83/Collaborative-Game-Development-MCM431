using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource ThisMusicSource;
    [SerializeField] private AudioSource ThisSFXSource;

    [Header("====== Audio Clips ======")]
    [SerializeField] public AudioClip[] audioClips;

    private int GetAudioClip(string clipToPlay)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            AudioClip clipIteration = audioClips[i];

            if (clipIteration.name == clipToPlay)
            {
                return i;
            }
        }
        Debug.LogError($"Target Audio Clip: {clipToPlay}, was not found within the AudioClips Array, double check spelling or present array members to ensure you are referencing the correct clip");
        return -1;
    }

    public void PlayAudio(string clipToPlay, string channelType)
    {
        switch (channelType)
        {
            case "Music":
                PlayMusic(clipToPlay);
                break;
            case "SFX":
                PlaySFX(clipToPlay);
                break;
            default:
                Debug.LogError("Audio Mixer Channel Type is invalid. Change the channel type to be either 'Music' or 'SFX'");
                break;
        }
    }

    private void PlayMusic(string clipToPlay)
    {
        int audioClipArrayPosition = GetAudioClip(clipToPlay);
        ThisMusicSource.PlayOneShot(audioClips[audioClipArrayPosition]);
    }
    private void PlaySFX(string clipToPlay)
    {
        int audioClipArrayPosition = GetAudioClip(clipToPlay);
        ThisSFXSource.PlayOneShot(audioClips[audioClipArrayPosition]);
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
