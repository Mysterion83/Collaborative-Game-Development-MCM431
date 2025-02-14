using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("====== Audio Mixers ======")]
    [SerializeField] public AudioMixer MainAudioMixer;

    [Header("====== Audio Sources ======")]
    [SerializeField] private AudioSource MasterAudioSource;
    [SerializeField] private AudioSource MusicAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;

    [Header("====== Music Clips ======")]
    [SerializeField] public AudioClip[] musicClips;

    [Header("====== SFX Clips ======")]
    [SerializeField] public AudioClip[] sfxClips;

    // Audio Management //
    public void PlayMusic(AudioClip clipToPlay)
    {
        MusicAudioSource.PlayOneShot(clipToPlay);
    }
    public void PlaySFX(AudioClip clipToPlay)
    {
        SFXAudioSource.PlayOneShot(clipToPlay);
    }

    public void PauseMusic()
    {
        MusicAudioSource.Pause();
    }
    public void PauseSFX()
    {
        SFXAudioSource.Pause();
    }
    public void PauseAllSounds()
    {
        PauseMusic();
        PauseSFX();
    }

    public void StopMusic()
    {
        MusicAudioSource.Stop();
    }
    public void StopSFX()
    {
        SFXAudioSource.Stop();
    }
    public void StopAllSounds()
    {
        StopMusic();
        StopSFX();
    }
}
