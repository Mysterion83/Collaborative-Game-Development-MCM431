using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest Instance;

    public List<string> collectedItems = new List<string>();
    public Vector3 playerPosition;
    public List<string> completedEvents = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelName");
        Debug.Log("GameStarted");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has closed");
    }

    public void AddCollectedItem(string item)
    {
        if (!collectedItems.Contains(item))
            collectedItems.Add(item);
    }

    public void SetPlayerPosition(Vector3 newPosition)
    {
        playerPosition = newPosition;
    }

    public void AddCompletedEvent(string eventName)
    {
        if (!completedEvents.Contains(eventName))
            completedEvents.Add(eventName);
    }
}