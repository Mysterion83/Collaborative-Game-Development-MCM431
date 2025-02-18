using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            _instance = this;
        }
    }
}
