using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Scene names required for navigation
    public string TitleScreenScene;
    public string Level1Scene; // Will be removed once the save file system is fully implemented
    [SerializeField] GameObject TitleScreenPanel;
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject SettingsPanel;

    private void Start()
    {
        SettingsPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

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
            SceneManager.LoadSceneAsync(Level1Scene, LoadSceneMode.Single);
        }
    }

    // ToggleControlsPanel() and ToggleSettingsPanel() will alternate between showing the title screen and their namesake panels based on their active states in the inspector
    public void ToggleControlsPanel()
    {
        if (!ControlsPanel.activeSelf)
        {
            TitleScreenPanel.SetActive(false);
            ControlsPanel.SetActive(true);
        }
        else
        {
            TitleScreenPanel.SetActive(true);
            ControlsPanel.SetActive(false);
        }
    }

    public void ToggleSettingsPanel()
    {
        if (!SettingsPanel.activeSelf)
        {
            TitleScreenPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
        else
        {
            TitleScreenPanel.SetActive(true);
            SettingsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Exited game");
        Application.Quit();
    }
}
