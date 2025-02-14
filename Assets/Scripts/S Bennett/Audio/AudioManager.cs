using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("====== Audio Mixers ======")]
    [SerializeField] private AudioMixer MainAudioMixer;

    [Header("====== Sliders ======")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("====== Audio Clips ======")]

    void Start()
    {
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
