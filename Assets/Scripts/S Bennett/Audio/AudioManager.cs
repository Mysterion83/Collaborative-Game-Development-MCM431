using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("====== Audio Mixers ======")]
    [SerializeField] public AudioMixer MainAudioMixer;

    [Header("====== Music Clips ======")]
    [SerializeField] public AudioClip[] musicClips;

    [Header("====== SFX Clips ======")]
    [SerializeField] public AudioClip[] sfxClips;

    public void PlayMusicFromSource(AudioClip clipToPlay, AudioSource targetAudioSource)
    {
        targetAudioSource.PlayOneShot(clipToPlay);
    }
    public void PlaySFXFromSource(AudioClip clipToPlay, AudioSource targetAudioSource)
    {
        targetAudioSource.PlayOneShot(clipToPlay);
    }

    public void PauseMusicFromSource(AudioSource targetAudioSource)
    {
        targetAudioSource.Pause();
    }
    public void PauseSFXFromSource(AudioSource targetAudioSource)
    {
        targetAudioSource.Pause();
    }
    public void PauseAllSounds(AudioSource targetAudioSource)
    {
        PauseMusicFromSource(targetAudioSource);
        PauseSFXFromSource(targetAudioSource);
    }

    public void StopMusicFromSource(AudioSource targetAudioSource)
    {
        targetAudioSource.Stop();
    }
    public void StopSFXFromSource(AudioSource targetAudioSource)
    {
        targetAudioSource.Stop();
    }
    public void StopAllSoundsFromSource(AudioSource targetAudioSource)
    {
        StopMusicFromSource(targetAudioSource);
        StopSFXFromSource(targetAudioSource);
    }
}
