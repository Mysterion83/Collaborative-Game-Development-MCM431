using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider brightnessSlider;
    public TMP_Text masterVolumePercentageText;
    public TMP_Text SFXVolumePercentageText;
    public TMP_Text MusicVolumePercentageText;

    [Header("Other")]
    public Material brightnessMaterial;

    private AudioMixer MainAudioMixer;
    private Resolution[] resolutions;

    void Start()
    {
        //Populating the Resolution Dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
        SetResolution(resolutionDropdown.value);

        // Populating the Graphics Dropdown
        if (graphicsDropdown != null)
        {
            graphicsDropdown.ClearOptions();
            graphicsDropdown.AddOptions(new List<string> { "Low", "Medium", "High", "Ultra" });
            graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());
            graphicsDropdown.RefreshShownValue();
            SetGraphicsQuality(graphicsDropdown.value);
            graphicsDropdown.onValueChanged.AddListener(SetGraphicsQuality);

        }

        MainAudioMixer = AudioManager.Instance.MainAudioMixer;

        //Loads saved volume and brightness values
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1f);

        //Applies initial volume settings
        SetMasterVolume(masterVolumeSlider.value);
        SetSFXVolume(sfxVolumeSlider.value);
        SetMusicVolume(musicVolumeSlider.value);

        //Setting Initial text value for volume %'s
        UpdateMasterVolumeText(masterVolumeSlider.value);
        masterVolumeSlider.onValueChanged.AddListener(UpdateMasterVolumeText);
        
        UpdateSFXVolumeText(sfxVolumeSlider.value);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolumeText);

        UpdateMusicVolumeText(musicVolumeSlider.value);
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolumeText);
    }

    //----------------------Resolution & Graphics-------------------------------

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length) return;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.FullScreenWindow);
        Debug.Log($"Resolution Set To: {resolution.width} x {resolution.height}");
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log($"Graphics Quality Set To: {QualitySettings.names[qualityIndex]}");
    }

    //----------------------Volume Settings-------------------------------

    public void SetMasterVolume(float volume)
    {
        MainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); //Converts Slider value to decibels
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        //audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20); 
        MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        //audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        MainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void UpdateMasterVolumeText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        masterVolumePercentageText.text = "Master Volume " + percentage + "%";        
    }
    public void UpdateSFXVolumeText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        SFXVolumePercentageText.text = "SFX Volume " + percentage + "%";
    }
    public void UpdateMusicVolumeText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        MusicVolumePercentageText.text = "Music Volume " + percentage + "%";
    }

    //----------------------Brightness Settings-------------------------------

    public void SetBrightness(float brightness)
    {
        brightnessMaterial.SetFloat("_Brightness", brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
    }

    //----------------------Apply Settings-------------------------------

    public void ApplySettings()
    {
        SetResolution(resolutionDropdown.value);
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);

        if (graphicsDropdown != null)
        {
            PlayerPrefs.SetInt("GraphicsQuality", graphicsDropdown.value);
        }

        SetMasterVolume(masterVolumeSlider.value);
        SetSFXVolume(sfxVolumeSlider.value);
        SetMusicVolume(musicVolumeSlider.value);

        SetBrightness(brightnessSlider.value);

        PlayerPrefs.Save();

        Debug.Log("Settings Applied and Saved");
    }
}