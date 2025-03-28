using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Scene names required for navigation
    public string TitleScreenScene;
    public string Level1Scene; // Will be removed once the save file system is fully implemented
    public string CreditsScene;

    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject ControlsPanel;

    private void Start()
    {
        SettingsPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

    // ------------ LOADING SCENES ------------

    // Title Screen button functions - prior to complete implementation of save file system
    public void LoadTitleScreen()
    {
        if (TitleScreenScene == "")
        {
            Debug.LogWarning("Title screen scene name not provided");
        }
        else
        {
            SceneManager.LoadSceneAsync(TitleScreenScene, LoadSceneMode.Single);
        }
    }

    //  Play() will become redundant once the save file system is complete; two new functions, LoadNewGame() and LoadSaveFile(), will be implemented to handle loading either a new or old save file from the title screen
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
        if (CreditsScene == "")
        {
            Debug.LogWarning("Credits scene name not provided");
        }
        else
        {
            SceneManager.LoadSceneAsync(CreditsScene, LoadSceneMode.Single);
        }
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
