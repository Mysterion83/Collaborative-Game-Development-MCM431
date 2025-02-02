using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // SCENE NAMES REQUIRED FOR NAVIGATON
    [SerializeField] public string TitleScreenScene;
    [SerializeField] public string GameScene;
    [SerializeField] public string SettingsMenuScene;

    // SCENE NAVIGATION
    public void LoadTitleScreen()
    {
        if (string.IsNullOrEmpty(TitleScreenScene))
        {
            Debug.LogWarning("TITLE SCREEN SCENE NAME NOT PROVIDED");
        }
        else
        {
            SceneManager.LoadSceneAsync(TitleScreenScene, LoadSceneMode.Single);
        }
    }

    public void LoadGame()
    {
        if (string.IsNullOrEmpty(GameScene))
        {
            Debug.LogWarning("GAME SCENE NAME NOT PROVIDED");
        }
        else
        {
            SceneManager.LoadSceneAsync(GameScene, LoadSceneMode.Single);
        }
    }

    public void LoadSettingsMenu()
    {
        if (string.IsNullOrEmpty(SettingsMenuScene))
        {
            Debug.LogWarning("SETTINGS MENU SCENE NAME NOT PROVIDED");
        }
        else
        {
            SceneManager.LoadSceneAsync(SettingsMenuScene, LoadSceneMode.Single);
        }
    }

    public void QuitGame()
    {
        Debug.Log("EXITED GAME ON TITLE SCREEN");
        Application.Quit();
    }
}
