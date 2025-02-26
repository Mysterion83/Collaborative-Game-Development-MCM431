using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ExitGame()
    {
        GameManagerTest.Instance.QuitGame();
    }
}
