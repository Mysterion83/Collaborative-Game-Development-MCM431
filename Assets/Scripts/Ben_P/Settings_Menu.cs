using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public AudioMixer audioMixer;
    public Material brightnessMaterial;

    private Resolution[] resolutions;

    void Start()
    {
        //Populate resolution dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Load Saved Settings
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1f);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Debug.Log($"Resolution Set To: {resolution.width} x {resolution.height}");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetBrightnesss(float brightness)
    {
        brightnessMaterial.SetFloat("_Brightness", brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
    }

    public void ApplySettings()
    {
        //Applies Resolution
        SetResolution(resolutionDropdown.value);

        // Save all settings the player has changed
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Brightness", brightnessSlider.value);
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);

        // Force save to prevent data loss
        PlayerPrefs.Save();
    }
}