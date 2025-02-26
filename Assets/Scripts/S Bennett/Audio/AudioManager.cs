using UnityEngine;
using UnityEngine.Audio;

public enum AudioMixerChannels
{
    Music,
    SFX
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer MainAudioMixer;

    [Header("====== Music Clips ======")]
    public AudioClip[] musicClips;

    [Header("====== SFX Clips ======")]
    public AudioClip[] sfxClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetMusicClip(string clipToPlay)
    {
        for (int i = 0; i < musicClips.Length; i++)
        {
            AudioClip clipIteration = musicClips[i];

            if (clipIteration.name == clipToPlay)
            {
                return i;
            }
        }
        Debug.LogError($"Target Audio Clip: {clipToPlay}, was not found within the Music Array, double check spelling or present array members to ensure you are referencing the correct clip");
        return -1;
    }

    public int GetSFXClip(string clipToPlay)
    {
        for (int i = 0; i < sfxClips.Length; i++)
        {
            AudioClip clipIteration = sfxClips[i];

            if (clipIteration.name == clipToPlay)
            {
                return i;
            }
        }
        Debug.LogError($"Target Audio Clip: {clipToPlay}, was not found within the SFX Array, double check spelling or present array members to ensure you are referencing the correct clip");
        return -1;
    }
}
