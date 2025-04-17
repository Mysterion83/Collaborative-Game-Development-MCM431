using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Main game scene name required for Play()
    public string Level1Scene;


    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject ControlsPanel;

    private void Start()
    {
        SettingsPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

    // ------------ LOADING SCENES ------------

    public void LoadTitleScreen()
    {
        SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
    }

    public void Play()
    {
        if (Level1Scene == "")
        {
            Debug.LogWarning("Level 1 scene name not provided");
        }
        else
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync("Final Credits", LoadSceneMode.Single);
    }


    // ------------ TOGGLING PANELS ------------

    // ToggleControls() will alternate between showing the title screen and settings panel based on their active states
    public void ToggleControls()
    {
        if (!ControlsPanel.activeSelf)
        {
            ControlsPanel.SetActive(true);
        }
        else
        {
            ControlsPanel.SetActive(false);
        }
    }

    public void ToggleSettings()
    {
        if (!SettingsPanel.activeSelf)
        {
            SettingsPanel.SetActive(true);
        }
        else
        {
            SettingsPanel.SetActive(false);
        }
    }



    public void QuitGame()
    {
        Debug.Log("Exited game");
        Application.Quit();
    }
}
