using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Obsolete("This class is obsolete and is only meant for testing purposes. Audio settings are now handled within the settings script.")]
public class AudioSettings : MonoBehaviour
{
    private AudioMixer MainAudioMixer;

    [Header("====== Sliders ======")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        MainAudioMixer = AudioManager.Instance.MainAudioMixer;

        // Checks if audio settings have been previously stored before //
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadAllChannelVolumes();
        }
        else // Audio settings setup in case audio has not been previously setup or accidentally deleted //
        {
            SetMasterChannelVolume();
            SetMusicChannelVolume();
            SetSFXChannelVolume();
        }
    }

    // Audio Settings //
    // Log10 applies the volume logarithmically, with a min value of 0.0001 & a max volume of 10000 //
    public void SetMasterChannelVolume()
    {
        float masterVolume = masterSlider.value;
        MainAudioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
    }

    public void SetMusicChannelVolume()
    {
        float musicVolume = musicSlider.value;
        MainAudioMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void SetSFXChannelVolume()
    {
        float sfxVolume = sfxSlider.value;
        MainAudioMixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
    }

    public void LoadAllChannelVolumes()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMasterChannelVolume();
        SetMusicChannelVolume();
        SetSFXChannelVolume();
    }
}
