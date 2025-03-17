using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsPrefab;
    public GameObject controlsPrefab;
    private bool isPaused = false;
    private PlayerCamera playerCamera;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Find the PlayerCamera script in the scene
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerCamera != null)
            playerCamera.SetPaused(false); // Resume camera movement
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerCamera != null)
            playerCamera.SetPaused(true); // Stop camera movement

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsPrefab.SetActive(true);
    }

    public void OpenControls()
    {
        pauseMenuUI.SetActive(false);
        controlsPrefab.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
