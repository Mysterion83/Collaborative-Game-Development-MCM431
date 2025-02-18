using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DocumentDisplayManager : MonoBehaviour
{
    public static DocumentDisplayManager Instance { get { return _instance; } }
    private static DocumentDisplayManager _instance;
    
    [SerializeField]
    TextMeshProUGUI DocumentTextLeft;

    [SerializeField]
    TextMeshProUGUI DocumentTextRight;

    [SerializeField]
    GameObject Book;

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

    public void DisplayDocument(string Text)
    {
        Book.SetActive(true);
        DocumentTextLeft.text = Text;
        //DocumentTextRight.text = SplitText(Text, 325)[1];
    }
    public void Update() 
    {
        if (Book.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Book.SetActive(false);
        }
    }

    public string[] SplitText(string Text)
    {
        return null;
    }
}
