using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField] private AudioSource ThisMusicSource;
    [SerializeField] private AudioSource ThisSFXSource;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    // Called whenever a specific Audio Controller is needed to play Audio
    public void PlayAudioClip(string clipToPlay, AudioMixerChannels channelType)
    {
        switch (channelType)
        {
            case AudioMixerChannels.Music:
                PlayMusic(clipToPlay);
                break;
            case AudioMixerChannels.SFX:
                PlaySFX(clipToPlay);
                break;
            default:
                Debug.LogError("Audio Mixer Channel Type is invalid. Change the channel type to be either 'Music' or 'SFX'");
                break;
        }
    }

    // Attempts to Play Audio, if the audioClipArrayPosition is -1 (due to the clip not being found),
    // It will throw an error saying the clip was not found and return to prevent an 'array out of bounds' error
    private void PlayMusic(string clipToPlay)
    {
        int audioClipArrayPosition = audioManager.GetMusicClip(clipToPlay);
        if (audioClipArrayPosition == -1) return;

        ThisMusicSource.PlayOneShot(audioManager.musicClips[audioClipArrayPosition]);
    }
    private void PlaySFX(string clipToPlay)
    {
        int audioClipArrayPosition = audioManager.GetSFXClip(clipToPlay);
        if (audioClipArrayPosition == -1) return;

        ThisSFXSource.PlayOneShot(audioManager.sfxClips[audioClipArrayPosition]);
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
