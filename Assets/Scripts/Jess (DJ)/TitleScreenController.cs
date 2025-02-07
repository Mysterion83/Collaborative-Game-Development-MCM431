using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // SCENE NAMES REQUIRED FOR NAVIGATON
    [SerializeField] public string TitleScreenScene;
    [SerializeField] public string Level1Scene;
    [SerializeField] GameObject TitleScreenCanvas;
    [SerializeField] GameObject SettingsMenuCanvas;

    private void Start()
    {
        SettingsMenuCanvas.SetActive(false);
    }


    // SCENE NAVIGATION BETWEEN TITLE AND GAME
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

    public void Settings()
    {
        if (!SettingsMenuCanvas.activeSelf)
        {
            TitleScreenCanvas.SetActive(false);
            SettingsMenuCanvas.SetActive(true);
        }
        else
        {
            TitleScreenCanvas.SetActive(true);
            SettingsMenuCanvas.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Exited game");
        Application.Quit();
    }
}
